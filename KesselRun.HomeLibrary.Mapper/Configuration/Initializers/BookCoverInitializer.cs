using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class BookCoverInitializer : MappingBase, IMappingInitializer
    {
        public BookCoverInitializer(Profile profile) : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.BookCover, UiLogic.Models.BookCover>();
        }
    }
}
