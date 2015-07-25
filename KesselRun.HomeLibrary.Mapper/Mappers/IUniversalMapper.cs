using System;

namespace KesselRun.HomeLibrary.Mapper.Mappers
{
    public interface IUniversalMapper : IDisposable
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
