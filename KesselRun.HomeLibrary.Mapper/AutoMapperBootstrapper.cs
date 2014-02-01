using AutoMapper;
using AutoMapper.Mappers;
using KesselRun.HomeLibrary.Mapper.Profiles;

namespace KesselRun.HomeLibrary.Mapper
{
    public class AutoMapperBootstrapper
    {
        public IConfiguration Configuration { get; set; }
        
        public IConfigurationProvider ConfigurationProvider
        {
            get { return (IConfigurationProvider)Configuration; }
        }

        public void Initialize()
        {
            Configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);

            var profile = new HomeLibraryProfile();

            Configuration.AddProfile(profile);
        }
    }
}
