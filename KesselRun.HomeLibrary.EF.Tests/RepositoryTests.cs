using System.Linq;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;

namespace KesselRun.HomeLibrary.EF.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var context = new HomeLibraryContext();
            context.Database.Initialize(true);
        }

        [TestMethod]
        public void GetAllReturnsAllPeople()
        {
            var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

            var personRepo = unitOfWork.Repository<Person>();

            Assert.IsTrue(personRepo.Query().Select().Count() == 2);
        }

    }
}
