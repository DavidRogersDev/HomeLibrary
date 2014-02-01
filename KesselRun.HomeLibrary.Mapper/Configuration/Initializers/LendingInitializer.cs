using AutoMapper;

namespace KesselRun.HomeLibrary.Mapper.Configuration.Initializers
{
    public class LendingInitializer : MappingBase, IMappingInitializer
    {
        public LendingInitializer(Profile profile) : base(profile)
        {
        }

        public void Initialize()
        {
            Profile.CreateMap<Model.Lending, UiLogic.Models.Lending>();
        }

    }
}
