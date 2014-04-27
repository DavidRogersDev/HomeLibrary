using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Validation;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Service.CommandHandlers.Decorators
{
    public class AddLendingHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnityContainer _container;
        private readonly IValidator _validator;

        public AddLendingHandlerDecorator(ICommandHandler<TCommand> commandHandler, IUnityContainer container)
        {
            _commandHandler = commandHandler;
            _container = container;
            //_validator = validator;
        }


        public void Handle(TCommand command)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(command.GetType());
            dynamic validator = _container.Resolve(validatorType);

            var bla = validator.Validate(command);

            _commandHandler.Handle(command);
        }
    }
}
