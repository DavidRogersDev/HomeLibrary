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

        public void ProcessCommand<TCommand>(ICommandHandler<TCommand> command)
        {
            var handlerType = typeof (ICommandHandler<TCommand>).MakeGenericType(command.GetType(), typeof (TCommand));
            dynamic handler = _container.Resolve(handlerType);

            handler.ProcessCommand((dynamic) command);
        }
    }
}
