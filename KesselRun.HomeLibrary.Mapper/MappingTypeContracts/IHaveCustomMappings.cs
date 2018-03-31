using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.MappingTypeContracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(Profile configuration);
    }
}