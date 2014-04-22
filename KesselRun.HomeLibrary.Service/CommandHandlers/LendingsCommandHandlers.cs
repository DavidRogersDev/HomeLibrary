using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;

namespace KesselRun.HomeLibrary.Service.CommandHandlers
{
    public class LendingsCommandHandlers : ICommandHandler<AddLendingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LendingsCommandHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(AddLendingCommand command)
        {
            _unitOfWork.Lendings.Add(new Lending
            {
                BookId = command.BookId,
                BorrowerId = command.BorrowerId,
                DateLent = command.DateLent,
                DueDate = command.DateDue
            });

            _unitOfWork.Lendings.Save();
        }
    }
}
