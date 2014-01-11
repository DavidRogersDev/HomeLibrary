using System.Data.Entity;

namespace KesselRun.HomeLibrary.Model.Db
{
    public class HomeLibraryContext : DbContext
    {
        //  DbSets go here

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
