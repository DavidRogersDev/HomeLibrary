using System;
using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Mappers
{
    public class UniversalMapper : IUniversalMapper
    {
        private readonly IMappingEngine _mappingEngine;
        private bool _disposed = false;

        public UniversalMapper(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public virtual TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mappingEngine.Map(source, destination);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _mappingEngine.Dispose();
            }

            _disposed = true;
        }
    }
}
