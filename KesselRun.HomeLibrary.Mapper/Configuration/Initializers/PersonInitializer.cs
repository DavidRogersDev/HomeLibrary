using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class PersonInitializer : MappingBase, IMappingInitializer
    {
        public PersonInitializer(Profile profile) : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Person, UiModel.Models.Person>()
                .ForMember(viewType => viewType.FullName, domainType => domainType.MapFrom(p => p.FirstName + " " + p.LastName));
        }
    }
}
