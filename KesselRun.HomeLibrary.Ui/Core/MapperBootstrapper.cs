using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.Mapper.Profiles;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public class MapperBootstrapper : IBootstrapper
    {
        public void Configure()
        {
            var profile = new HomeLibraryProfile();
            AutoMapper.Mapper.Initialize(p => p.AddProfile(profile));
        }
    }
}
