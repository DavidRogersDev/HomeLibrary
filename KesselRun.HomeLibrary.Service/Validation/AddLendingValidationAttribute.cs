using System.ComponentModel.DataAnnotations;

namespace KesselRun.HomeLibrary.Service.Validation
{
    public class AddLendingValidationAttribute : ValidationAttribute
    {

        public AddLendingValidationAttribute()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
