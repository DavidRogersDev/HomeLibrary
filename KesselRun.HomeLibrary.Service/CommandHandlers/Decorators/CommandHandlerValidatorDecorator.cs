using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.ObjectResolution;
using Ninject;

namespace KesselRun.HomeLibrary.Service.CommandHandlers.Decorators
{
    public class CommandHandlerValidatorDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IKernel _kernel;
        private bool _disposed = false;
        private dynamic _validator;

        public CommandHandlerValidatorDecorator(ICommandHandler<TCommand> commandHandler, IKernel kernel)
        {
            _commandHandler = commandHandler;
            _kernel = kernel;
        }


        public void Handle(TCommand command)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(command.GetType());
            _validator = _kernel.Get(validatorType);

            ValidationResult validateResult = _validator.Validate(command);

            if (validateResult.IsValid)
            {
                _commandHandler.Handle(command);
            }
            else
            {
                throw new ValidationException(validateResult.Errors);
            }
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
                var disposable = _validator as IDisposable;
                if(!ReferenceEquals(disposable, null))
                    disposable.Dispose();
                _commandHandler.Dispose();
            }

            _disposed = true;
        }
    }
}
