namespace KesselRun.HomeLibrary.Mapper
{
    public class MapperBootstrapper
    {
        public void Initialize()
        {
            var profile = new HomeLibraryProfile();
            AutoMapper.Mapper.Initialize(p => p.AddProfile(profile));
        }
    }
}
