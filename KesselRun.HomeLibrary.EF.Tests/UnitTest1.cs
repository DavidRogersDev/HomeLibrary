using System;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KesselRun.HomeLibrary.EF.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PersonRepository pr = new PersonRepository(new HomeLibraryContext());

            var bla = pr.GetAll();

            pr.Add(new Person { Email="", IsAuthor=true, FirstName=".",LastName="",Sobriquet="" });

            bla = pr.GetAll();

            Assert.IsTrue(bla.Count > 0);
        }
    }
}
