
namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface ICommandProcessor
    {
        void Execute(dynamic command);
    }
}
