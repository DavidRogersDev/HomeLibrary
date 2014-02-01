using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class BookInitializer : MappingBase, IMappingInitializer
    {
        public BookInitializer(Profile profile) : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Book, UiLogic.Models.Book>();
        }
    }
}
