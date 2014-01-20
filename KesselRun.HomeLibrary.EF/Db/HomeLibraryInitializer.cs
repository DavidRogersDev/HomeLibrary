using System.Data.Entity;
using KesselRun.HomeLibrary.EF.Db;

namespace KesselRun.HomeLibrary.EF.Db
{
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            base.Seed(context);
        }
    }
}
