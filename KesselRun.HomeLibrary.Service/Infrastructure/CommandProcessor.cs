using System;
using Ninject;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public sealed class CommandProcessor : ICommandProcessor, IDisposable
    {
        private readonly IKernel _kernel;
        private bool _disposed;
        private dynamic _commandHandler;

        public CommandProcessor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Execute(dynamic command)
        {
            Type commandHandlerType = typeof (ICommandHandler<>).MakeGenericType(command.GetType());

            _commandHandler = _kernel.Get(commandHandlerType);

            _commandHandler.Handle(command);
        }

        public void Dispose()
        {
            //Trace.TraceInformation("Unity obj in CP " + _container.GetHashCode().ToString());
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _commandHandler.Dispose();
                _disposed = true;
            }
        }
    }
}
