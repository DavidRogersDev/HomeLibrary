﻿using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Db
{
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            new List<Person> { new Person { FirstName = "Terry", LastName = "Halpin", Email = "hi", IsAuthor = false},
                new Person { FirstName = "Alan", LastName = "Turing", Email = "hi", IsAuthor = false }
                , }.ForEach(p => context.People.Add(p));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
