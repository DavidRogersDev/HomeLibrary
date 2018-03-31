using AutoMapper;
using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;

namespace KesselRun.HomeLibrary.UiModel.CustomMappers
{
    public class PersonMapConfigurer : IHaveCustomMappings
    {
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Model.Person, Models.Person>()
                .ForMember(viewType => viewType.FullName, domainType => domainType.MapFrom(p => p.FirstName + " " + p.LastName));
        }
    }
}
