using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Model;
using Repository.Pattern.Infrastructure;

namespace KesselRun.HomeLibrary.EF.Tests
{
    public class HomeLibraryTestInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            var terry = new Person
            {
                FirstName = "Terry",
                LastName = "Halpin",
                Email = "hi",
                IsAuthor = false,
                ObjectState = ObjectState.Added
            };

            var alan = new Person
            {
                FirstName = "Alan",
                LastName = "Turing",
                Email = "hi",
                IsAuthor = false,
                ObjectState = ObjectState.Added
            };

            context.People.AddRange(new List<Person> {alan, terry});

            base.Seed(context);
        }
    }
}
