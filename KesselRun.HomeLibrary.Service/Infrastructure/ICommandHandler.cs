namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
