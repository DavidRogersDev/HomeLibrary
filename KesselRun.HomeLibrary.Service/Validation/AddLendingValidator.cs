using System.Linq;
using FluentValidation;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.Validation
{
    public class AddLendingValidator : AbstractValidator<AddLendingCommand>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public AddLendingValidator(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.DateDue).NotNull().WithMessage("The Due Date cannot be null.");
            RuleFor(c => c.BookId).Must(BookNotAlreadyLent).WithMessage("The book is currently on loan to another person.");
        }

        private bool BookNotAlreadyLent(int bookId)
        {
            var book = _unitOfWork.Repository<Model.Book>().Query(b => b.Id == bookId).Include(b => b.Lendings).Select().SingleOrDefault();
            Lending loanNotReturned = null;

            if (!ReferenceEquals(null, book))
            {
                book.Lendings.FirstOrDefault(l => l.ReturnDate == null);
            }

            return ReferenceEquals(null, loanNotReturned);
        }

    }
}
