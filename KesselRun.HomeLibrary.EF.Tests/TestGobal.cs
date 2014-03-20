using System.Data.Entity;
using KesselRun.HomeLibrary.EF.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KesselRun.HomeLibrary.EF.Tests
{
    [TestClass]
    public class Global
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //Database.SetInitializer(new HomeLibraryTestInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HomeLibraryContext, Migrations.Configuration>());
        }
    }
}
