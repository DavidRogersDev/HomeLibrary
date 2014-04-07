using System.Data.Entity;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.EF.Db;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DatabaseConfigurer : IBootstrapper
    {
        public void Configure()
        {
            Database.SetInitializer(new HomeLibraryInitializer());
        }
    }
}
