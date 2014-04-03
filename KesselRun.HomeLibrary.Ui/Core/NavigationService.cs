using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Common.Contracts;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _viewTypesCache;
        private readonly Dictionary<string,Stack<Control>> _controlStack = new Dictionary<string, Stack<Control>>();
        public Control NavigationRootControl { get; set; }

        private NavigationService()
        {
            _viewTypesCache = new Dictionary<Type, Type>();
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class NavigationServiceSingletonCreator
        {
            static NavigationServiceSingletonCreator()
            {

                
            }

            // Private object instantiated with private constructor
            internal static readonly NavigationService UniqueInstance = new NavigationService();
        }

        public static NavigationService SingleNavigationService
        {
            get
            {
                return NavigationServiceSingletonCreator.UniqueInstance;
            }
        }

        public void NavigateTo(Type view, Control containerControl)
        {
            var typeOfControl = GetViewTypeFromInterface(view);
            var constructors = typeOfControl.GetConstructors();
            var destinationView = constructors[0].Invoke(new object[] { });
            containerControl.Controls.Add((Control)destinationView);

            ManageStack((Control)destinationView, containerControl);
        }

        public void ManageStack(Control control, Control containerControl)
        {
            if (!_controlStack.ContainsKey(containerControl.Name))
            {
                _controlStack.Add(containerControl.Name, new Stack<Control>());
            }
            _controlStack[containerControl.Name].Push(control);
        }

        public Type GetViewTypeFromInterface(Type type)
        {
            Type viewType;

            if (_viewTypesCache.TryGetValue(type, out viewType))
            {
                return viewType;
            }

            var assembly = Assembly.GetExecutingAssembly();

            foreach (var exportedType in assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(Control))))
            {
                if (type.IsAssignableFrom(exportedType))
                {
                    viewType = exportedType;
                    break;
                }
            }
            
            _viewTypesCache.Add(type, viewType);

            return viewType;
        }
    }
}
