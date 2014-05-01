using System;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface ICommandHandler<in TCommand> : IDisposable
    {
        void Handle(TCommand command);
    }
}
