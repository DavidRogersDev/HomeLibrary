using System;
using System.Diagnostics;
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
            dynamic commandHandler = _container.Resolve(commandHandlerType, Constants.Commander);
            commandHandler.Handle(command);
        }

        public void Dispose()
        {
            Trace.TraceInformation("Unity obj in CP " + _container.GetHashCode().ToString());
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
