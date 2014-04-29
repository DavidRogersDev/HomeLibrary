using System;
using FluentValidation;
using FluentValidation.Results;
using KesselRun.HomeLibrary.Service.Infrastructure;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Service.CommandHandlers.Decorators
{
    public class CommandHandlerValidatorDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnityContainer _container;

        public CommandHandlerValidatorDecorator(ICommandHandler<TCommand> commandHandler, IUnityContainer container)
        {
            _commandHandler = commandHandler;
            _container = container;
        }


        public void Handle(TCommand command)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(command.GetType());
            dynamic validator = _container.Resolve(validatorType);

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
    }
}
