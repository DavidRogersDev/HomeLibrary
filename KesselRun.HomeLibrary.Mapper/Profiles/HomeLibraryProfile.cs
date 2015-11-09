using AutoMapper;
using KesselRun.HomeLibrary.Mapper.Configuration;

namespace KesselRun.HomeLibrary.Mapper.Profiles
{
    public class HomeLibraryProfile : Profile
    {
        const string HomeLibraryProfileName = "HomeLibraryProfile";

        public HomeLibraryProfile()
            : base(HomeLibraryProfileName)
        {
            
        }

        protected override void Configure()
        {
            // initialize mappings here
            new ViewModelMappings(this).Initialize();
        }
    }
}
