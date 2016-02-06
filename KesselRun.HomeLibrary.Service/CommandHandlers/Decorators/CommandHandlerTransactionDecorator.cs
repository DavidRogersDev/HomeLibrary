using System;
using System.Diagnostics;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.CommandHandlers.Decorators
{
    public class CommandHandlerTransactionDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private bool _disposed = false;

        public CommandHandlerTransactionDecorator(ICommandHandler<TCommand> commandHandler, IUnitOfWorkAsync unitOfWork)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
        }

        public void Handle(TCommand command)
        {
            try
            {
                _commandHandler.Handle(command);

                Trace.TraceInformation(_unitOfWork.GetHashCode().ToString());

                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }

        public void Dispose()
        {
            _commandHandler.Dispose();
            _unitOfWork.Dispose();
        }
    }
}
