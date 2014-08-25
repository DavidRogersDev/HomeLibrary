using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Tests.Infrastructure;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;

namespace KesselRun.HomeLibrary.EF.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private static TestContext _textContext;
        private const string DbExtension = ".sdf";

        [ClassInitialize]
        public static void ClassInitialize(TestContext textContext)
        {
            _textContext = textContext;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var context = new HomeLibraryContext();

            var _assembly = Assembly.GetExecutingAssembly();
            var mdf = _assembly.GetManifestResourceStream(string.Concat("KesselRun.HomeLibrary.EF.Tests.Db.HomeLibrary", DbExtension));
            var bytes = Utilities.ReadFully(mdf);
            File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("HomeLibrary", DbExtension)), bytes);
        }

        [TestCleanup]
        public void TearDown()
        {
            var context = new HomeLibraryContext();
            context.Database.Delete();
        }

        [TestMethod]
        [Ignore]
        public void GetAllReturnsAllPeople()
        {
            var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

            var personRepo = unitOfWork.Repository<Person>();

            Assert.IsTrue(personRepo.Query().Select().Count() == 2);
        }

        //[TestMethod]
        //[Ignore]
        //public void meth()
        //{
        //    var sdf = Properties.Resources.HomeLibrary;

        //    File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HomeLibrary.sdf"),sdf);

        //    var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

        //    var personRepo = unitOfWork.Repository<Person>();

        //    Assert.IsTrue(personRepo.Query().Select().Count() == 2);
        //    Trace.WriteLine(_textContext.DeploymentDirectory);
        //    Trace.WriteLine(_textContext.ResultsDirectory);
        //    Trace.WriteLine(_textContext.TestResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunDirectory);
        //}

        //[TestMethod]
        //public void meth2()
        //{
        //    var _assembly = Assembly.GetExecutingAssembly();
        //    var sdf = _assembly.GetManifestResourceStream("KesselRun.HomeLibrary.EF.Tests.Db.HomeLibrary.sdf");
        //    var bytes = ReadFully(sdf);

        //    File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HomeLibrary.sdf"), bytes);

        //    var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

        //    var personRepo = unitOfWork.Repository<Model.Person>();
        //    var ppeop = personRepo.Query().Select().ToList();

        //    //Assert.IsTrue(true);
        //    Assert.IsTrue(personRepo.Query().Select().Count() == 20);
        //    Trace.WriteLine(_textContext.DeploymentDirectory);
        //    Trace.WriteLine(_textContext.ResultsDirectory);
        //    Trace.WriteLine(_textContext.TestResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunDirectory);
        //}

        [TestMethod]
        public void meth2()
        {
            var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

            var personRepo = unitOfWork.Repository<Model.Person>();

            personRepo.Insert(new Person
            {
                FirstName = "dave",
                LastName = "rogers",
                Email = "Dave@dave.com",
                IsAuthor = false
            });

            unitOfWork.SaveChanges();

            var result = personRepo.Query().Select().Count();

            //Assert.IsTrue(true);
            Assert.IsTrue(result == 21);
            Trace.WriteLine(_textContext.DeploymentDirectory);
            Trace.WriteLine(_textContext.ResultsDirectory);
            Trace.WriteLine(_textContext.TestResultsDirectory);
            Trace.WriteLine(_textContext.TestRunResultsDirectory);
            Trace.WriteLine(_textContext.TestRunDirectory);
        }

        [TestMethod]
        public void meth3()
        {
            var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

            var personRepo = unitOfWork.Repository<Model.Person>();
            var ppeop = personRepo.Query().Select().ToList();

            personRepo.Insert(new Person
            {
                FirstName = "dave",
                LastName = "rogers",
                Email = "Dave@dave.com",
                IsAuthor = false
            });

            unitOfWork.SaveChanges();


            //Assert.IsTrue(true);
            Assert.IsTrue(personRepo.Query().Select().Any());
            Trace.WriteLine(_textContext.DeploymentDirectory);
            Trace.WriteLine(_textContext.ResultsDirectory);
            Trace.WriteLine(_textContext.TestResultsDirectory);
            Trace.WriteLine(_textContext.TestRunResultsDirectory);
            Trace.WriteLine(_textContext.TestRunDirectory);
        }

        [TestMethod]
        public void meth4()
        {
            var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

            var personRepo = unitOfWork.Repository<Model.Person>();
            var ppeop = personRepo.Query().Select().ToList();

            personRepo.Insert(new Person
            {
                FirstName = "dave",
                LastName = "rogers",
                Email = "Dave@dave.com",
                IsAuthor = false
            });

            unitOfWork.SaveChanges();



            //Assert.IsTrue(true);
            Assert.IsTrue(personRepo.Query().Select().Count() == 21);
            Trace.WriteLine(_textContext.DeploymentDirectory);
            Trace.WriteLine(_textContext.ResultsDirectory);
            Trace.WriteLine(_textContext.TestResultsDirectory);
            Trace.WriteLine(_textContext.TestRunResultsDirectory);
            Trace.WriteLine(_textContext.TestRunDirectory);
        }

        //[TestMethod]
        //public void meth2()
        //{
        //    var unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

        //    var personRepo = unitOfWork.Repository<Model.Person>();
        //    var ppeop = personRepo.Query().Select().ToList();

        //    //Assert.IsTrue(true);
        //    Assert.IsTrue(personRepo.Query().Select().Count() == 20);
        //    Trace.WriteLine(_textContext.DeploymentDirectory);
        //    Trace.WriteLine(_textContext.ResultsDirectory);
        //    Trace.WriteLine(_textContext.TestResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunResultsDirectory);
        //    Trace.WriteLine(_textContext.TestRunDirectory);
        //}

    }
}
