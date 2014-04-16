using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public static class ValidatorHelper
    {
        public static void RegisterBindingSourceValidations(Form form, ErrorProvider errorProvider)
        {
            //Requires.IsNotNull(form, "form");
            //Requires.IsNotNull(errorProvider, "errorProvider");

            RegisterBindingSourceValidationsRecursive(form, errorProvider);
        }

        private static void RegisterBindingSourceValidationsRecursive(Control control, ErrorProvider provider)
        {
            foreach (Control childControl in control.Controls)
            {
                RegisterBindingSourceValidationsForControl(childControl, provider);

                RegisterBindingSourceValidationsRecursive(childControl, provider);
            }
        }

        private static void RegisterBindingSourceValidationsForControl(Control control, ErrorProvider errorProvider)
        {
            AddDataAnnotationsValidations(control, errorProvider);
        }

        private static void AddDataAnnotationsValidations(Control control, ErrorProvider errorProvider)
        {
            var binding = (
                from dataBinding in control.DataBindings.Cast<Binding>()
                where dataBinding.DataSource is BindingSource
                let bindingSource = (BindingSource) dataBinding.DataSource
                where !string.IsNullOrEmpty(dataBinding.BindingMemberInfo.BindingMember)
                let modelType = bindingSource.GetEnumerableElementType()
                where modelType != null
                let controlProperty = control.GetType().GetProperty(dataBinding.PropertyName)
                let boundPropertyName = dataBinding.BindingMemberInfo.BindingMember
                select new {bindingSource, modelType, controlProperty, boundPropertyName}).FirstOrDefault();

            if (binding != null)
            {
                RegisterValidator(control, 
                    binding.controlProperty, 
                    binding.modelType, 
                    binding.boundPropertyName, 
                    () => binding.bindingSource.Current, errorProvider
                    );
            }
        }

        private static Type GetEnumerableElementType(this BindingSource bindingSource)
        {
            return (
                from intf in bindingSource.DataSource.GetType()
                    .GetInterfaces()
                where intf.IsGenericType
                where intf.GetGenericTypeDefinition() == typeof (IEnumerable<>)
                let type = intf.GetGenericArguments().Single()
                where type != typeof (object)
                select type)
                .SingleOrDefault();
        }

        public static void RegisterValidator(Control controlToValidate,
            PropertyInfo controlProperty,
            Type modelType, 
            string modelPropertyName,
            Func<object> instanceSelector, 
            ErrorProvider errorProvider)
        {
            //Requires.IsNotNull(controlToValidate, "controlToValidate");
            //Requires.IsNotNull(controlProperty, "controlProperty");
            //Requires.IsNotNull(modelType, "modelType");
            //Requires.IsNotNull(instanceSelector, "instanceSelector");
            //Requires.IsNotNull(errorProvider, "errorProvider");

            controlToValidate.CausesValidation = true;

            var propertyChain = GetPropertyChain(modelType, modelPropertyName).ToArray();

            PropertyInfo targetProperty = propertyChain.Last();

            var validator = new ControlValidator
            {
                ControlToValidate = controlToValidate,
                ControlProperty = controlProperty,
                PropertyChain = propertyChain,
                InstanceSelector = instanceSelector,
                ErrorProvider = errorProvider,
                ValidationAttributes = targetProperty.GetCustomAttributes<ValidationAttribute>().ToArray(),
                Converter = TypeDescriptor.GetConverter(targetProperty.PropertyType),
            };

            if (validator.ValidationAttributes.Any())
            {
                // This check seems redundant, since WinForms doesn't allow you to 
                // leave a form field when the
                // value can't be converted, which means the validator will not go off.
                if (validator.Converter == null)
                {
                    throw GetTypeConverterMissingException(targetProperty);
                }

                controlToValidate.Validating += (s, e) => validator.Validate();
            }
        }

        private static Exception GetTypeConverterMissingException(PropertyInfo modelProperty)
        {
            return new InvalidOperationException(string.Format(
                "Property '{0}' declared on type {1} cannot be used for validation. " +
                "There is no TypeConverter for type {2}.",
                modelProperty.Name,
                modelProperty.DeclaringType,
                modelProperty.PropertyType));
        }

        private static IEnumerable<PropertyInfo> GetPropertyChain(Type modelType, string modelPropertyName)
        {
            foreach (string propertyName in modelPropertyName.Split('.'))
            {
                var property = modelType.GetProperty(propertyName);

                if (property == null)
                {
                    throw new InvalidOperationException(string.Format(
                        "Property with name '{0}' could not be found on type {1}.",
                        propertyName, modelType.FullName));
                }

                modelType = property.PropertyType;

                yield return property;
            }
        }
    }

    internal class ControlValidator
        {
            public PropertyInfo[] PropertyChain { get; set; }
            public ValidationAttribute[] ValidationAttributes { get; set; }
            public TypeConverter Converter { get; set; }
            public Func<object> InstanceSelector { get; set; }
            public ErrorProvider ErrorProvider { get; set; }
            public Control ControlToValidate { get; set; }
            public PropertyInfo ControlProperty { get; set; }

            public void Validate()
            {
                ModelPropertyPair pair = this.GetModelPropertyChain().Last();

                object value = this.GetValueToValidate();

                object convertedValue;

                if (!this.TryConvertValue(value, out convertedValue))
                {
                    this.ErrorProvider.SetError(this.ControlToValidate,
                        "Value is invalid.");
                    return;
                }

                string errorMessage = this.GetValidationErrorOrNull(pair, convertedValue);

                this.ErrorProvider.SetError(this.ControlToValidate, errorMessage);
            }

            private IEnumerable<ModelPropertyPair> GetModelPropertyChain()
            {
                var model = this.InstanceSelector();

                foreach (var property in this.PropertyChain)
                {
                    yield return new ModelPropertyPair(model, property);

                    model = model == null ? null : property.GetValue(model);
                }
            }

            private object GetValueToValidate()
            {
                return this.ControlProperty.GetValue(this.ControlToValidate);
            }

            [DebuggerStepThrough]
            private string GetValidationErrorOrNull(ModelPropertyPair pair, object value)
            {
                var context = new ValidationContext(pair.Model) {MemberName = pair.Property.Name};

                try
                {
                    Validator.ValidateValue(value, context, this.ValidationAttributes);
                    return null;
                }
                catch (ValidationException ex)
                {
                    return ex.Message;
                }
            }

            [DebuggerStepThrough]
            private bool TryConvertValue(object rawValue, out object convertedValue)
            {
                if (rawValue != null && rawValue.GetType() == this.PropertyChain.Last().PropertyType)
                {
                    convertedValue = rawValue;
                    return true;
                }

                try
                {
                    convertedValue = this.Converter.ConvertFrom(rawValue);
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.GetType().FullName + ".TryConvertValue (false): " + ex.Message);

                    // HACK: There is a bug in the .NET framework BaseNumberConverter class. The class throws an 
                    // Exception base class, and therefore we must catch the 'Exception' base class :-(.
                    convertedValue = null;
                    return false;
                }
            }
        }

    internal class ModelPropertyPair
    {
        public readonly object Model;
        public readonly PropertyInfo Property;

        public ModelPropertyPair(object model, PropertyInfo property)
        {
            this.Model = model;
            this.Property = property;
        }
    }

}
