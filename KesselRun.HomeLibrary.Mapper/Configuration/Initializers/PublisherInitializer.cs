using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class PublisherInitializer : MappingBase, IMappingInitializer
    {
        public PublisherInitializer(Profile profile)
            : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Publisher, UiModel.Models.Publisher>();
        }
    }
}
