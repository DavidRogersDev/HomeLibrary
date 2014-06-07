using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.CommandHandlers
{
    public class LendingsCommandHandlers : ICommandHandler<AddLendingCommand>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public LendingsCommandHandlers(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(AddLendingCommand command)
        {
            _unitOfWork.Repository<Model.Lending>().Insert(new Lending
            {
                BookId = command.BookId,
                BorrowerId = command.BorrowerId,
                DateLent = command.DateLent,
                DueDate = command.DateDue,
            });

            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
