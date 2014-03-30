using KesselRun.HomeLibrary.Common;
using KesselRun.HomeLibrary.Common.Contracts;

namespace KesselRun.HomeLibrary.Mapper
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
