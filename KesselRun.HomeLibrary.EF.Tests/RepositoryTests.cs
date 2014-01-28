using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var personRepository = new PersonRepository(new HomeLibraryContext());

            var persons = personRepository.GetAll();
            
            Assert.IsTrue(persons.Count == 2);
        }

    }
}
