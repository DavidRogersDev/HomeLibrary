using System.Collections.Generic;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Db.HomeLibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Db.HomeLibraryContext context)
        {
            new List<Person>
                {
                    new Person {FirstName = "Terry", LastName = "Halpin"},
                    new Person {FirstName = "Alan", LastName = "Turing"}
                }.ForEach(p => context.People.Add(p));

            context.SaveChanges();
        }
    }
}
