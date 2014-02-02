using AutoMapper;
using KesselRun.HomeLibrary.Mapper.Configuration;

namespace KesselRun.HomeLibrary.Mapper
{
    public class HomeLibraryProfile : Profile
    {
        public const string ViewModel = "HomeLibraryProfile";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            // initialize mappings here
            new ViewModelMappings(this).Initialize();
        }
    }
}
