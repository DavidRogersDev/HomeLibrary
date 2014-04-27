using System.ComponentModel.DataAnnotations;
using FluentValidation;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Validation
{
    public class AddLendingValidator : AbstractValidator<AddLendingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddLendingValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.DateDue).NotNull();
        }


    }
}
