using System.Linq;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KesselRun.HomeLibrary.EF.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private HomeLibraryContext context;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new HomeLibraryContext();
            context.Database.Initialize(true);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            context.Database.Delete();
        }

        [TestMethod]
        public void GetAllReturnsAllPeople()
        {
            var personRepository = new UnitOfWork(new RepositoryProvider(new RepositoryFactories()));

            var persons = personRepository.People.GetAll().ToList();

            Assert.IsTrue(persons.Count() == 3);
        }

    }
}
