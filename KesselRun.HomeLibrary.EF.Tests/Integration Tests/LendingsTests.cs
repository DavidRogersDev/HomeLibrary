using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Tests.Infrastructure;
using KesselRun.HomeLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KesselRun.HomeLibrary.EF.Tests.Integration_Tests
{
    [TestClass]
    public class LendingsTests
    {
        private static TestContext _textContext;
        private UnitOfWork _unitOfWork;
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

            _unitOfWork = new UnitOfWork(new HomeLibraryContext(), new RepositoryProvider(new RepositoryFactories()));

        }

        [TestCleanup]
        public void TearDown()
        {
            var context = new HomeLibraryContext();
            context.Database.Delete();
            context.Dispose();
        }

        [TestMethod]
        public void GetLendingsUsingBorrowerIdReturnsLendingsOfBorrower()
        {
            var repository = _unitOfWork.Repository<Lending>();

            var borrowers = repository.Query(l => l.Borrower.LastName.Contains("turing"))
                            .Include(l => l.Borrower)
                            .Include(l => l.Book)
                            .Select()
                            .ToList();

            Assert.IsTrue(borrowers.Count == 1);

            _unitOfWork.Dispose();
        }

    }
}
