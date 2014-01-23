using System.Data.Entity;

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
