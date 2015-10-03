using System;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    public interface IQueryHandlerFactory
    {
        dynamic Create(Type type);
    }

    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        public dynamic Create(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
