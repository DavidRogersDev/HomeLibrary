using System.Linq;
using FluentValidation;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;

namespace KesselRun.HomeLibrary.Service.Validation
{
    public class AddLendingValidator : AbstractValidator<AddLendingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddLendingValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.DateDue).NotNull();
            RuleFor(c => c.BookId).Must(BookNotAlreadyLent);
        }

        private bool BookNotAlreadyLent(int bookId)
        {
            var book = _unitOfWork.Books.GetSingleIncluding(bookId, b => b.Lendings);
            Lending loanNotReturned = null;

            if (!ReferenceEquals(null, book))
            {
                loanNotReturned = book.Lendings.FirstOrDefault(l => l.ReturnDate == null);
            }

            return ReferenceEquals(null, loanNotReturned);
        }

    }
}
