using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Mappers
{
    public class UniversalMapper : IUniversalMapper
    {
        private readonly IMappingEngine _mappingEngine;


        public UniversalMapper()
        {
        }

        public UniversalMapper(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public virtual TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mappingEngine.Map(source, destination);
        }
    }
}
