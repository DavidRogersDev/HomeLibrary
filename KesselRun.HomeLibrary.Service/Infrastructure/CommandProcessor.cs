using System;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public class CommandProcessor : ICommandProcessor, IDisposable
    {
        private readonly IUnityContainer _container;
        private bool _disposed;

        public CommandProcessor(IUnityContainer container)
        {
            _container = container;
        }

        public void Execute(dynamic command)
        {
            Type commandHandlerType = typeof (ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic commandHandler = _container.Resolve(commandHandlerType, "Commander");
            commandHandler.Handle(command);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _container.Dispose();
                _disposed = true;
            }
        }
    }
}
