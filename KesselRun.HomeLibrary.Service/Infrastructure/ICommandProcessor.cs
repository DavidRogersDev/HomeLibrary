
namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface ICommandProcessor
    {
        void ProcessCommand<TCommand>(ICommandHandler<TCommand> command);
    }
}
