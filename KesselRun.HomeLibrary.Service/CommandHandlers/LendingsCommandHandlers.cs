using System;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.ObjectResolution;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.CommandHandlers
{
    public class LendingsCommandHandlers : ICommandHandler<AddLendingCommand>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private bool _disposed = false;

        public LendingsCommandHandlers(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [TransactionAspect]
        public void Handle(AddLendingCommand command)
        {
            var newLending = new Lending
            {
                BookId = command.BookId,
                BorrowerId = command.BorrowerId,
                DateLent = command.DateLent,
                DueDate = command.DateDue,
                ObjectState = ObjectState.Added
            };

            _unitOfWork.Repository<Lending>().InsertGraph(newLending);

            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //_unitOfWork.Dispose();
            }

            _disposed = true;
        }
    }
}
