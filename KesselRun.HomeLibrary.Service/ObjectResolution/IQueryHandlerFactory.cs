using System;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    public interface IQueryHandlerFactory
    {
        dynamic Create(Type type);
    }
}
