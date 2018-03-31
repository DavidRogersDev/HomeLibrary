using System;
using System.Linq;
using AutoMapper;
using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;
using KesselRun.HomeLibrary.UiModel.CustomMappers;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class HomeLibraryProfile : Profile
    {
        const string HomeLibraryProfileName = "HomeLibraryProfile";

        public HomeLibraryProfile()
            : base(HomeLibraryProfileName)
        {
            ConfigureProfile();
        }

        private void ConfigureProfile()
        {
            var uiModelAssembly = typeof(PersonMapConfigurer).Assembly.GetExportedTypes(); // any type from that assembly will do.

            LoadStandardMappings(uiModelAssembly);
            LoadCustomMappings(uiModelAssembly);
        }

        private void LoadStandardMappings(Type[] coreAssemblyTypes)
        {
            var maps = (from t in coreAssemblyTypes
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                CreateMap(map.Source, map.Destination);
            }
        }

        private void LoadCustomMappings(Type[] coreAssemblyTypes)
        {
            var maps = (from t in coreAssemblyTypes
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(this);
            }
        }

    }
}
