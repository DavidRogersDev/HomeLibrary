using System;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IUnityContainer _container;

        public CommandProcessor(IUnityContainer container)
        {
            _container = container;
        }

        public void Execute(dynamic command)
        {
            Type commandHandlerType = typeof (ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic commandHandler = _container.Resolve(commandHandlerType);
            commandHandler.Handle(command);
        }
    }
}
