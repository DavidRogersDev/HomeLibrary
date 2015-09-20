using System;
using FluentValidation;
using FluentValidation.Results;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Ninject;

namespace KesselRun.HomeLibrary.Service.CommandHandlers.Decorators
{
    public class CommandHandlerValidatorDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IKernel _container;
        private bool _disposed = false;

        public CommandHandlerValidatorDecorator(ICommandHandler<TCommand> commandHandler, IKernel container)
        {
            _commandHandler = commandHandler;
            _container = container;
        }


        public void Handle(TCommand command)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(command.GetType());
            dynamic validator = _container.Get(validatorType);

            ValidationResult validateResult = validator.Validate(command);

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
                _commandHandler.Dispose();
                _container.Dispose();
            }

            _disposed = true;
        }
    }
}
