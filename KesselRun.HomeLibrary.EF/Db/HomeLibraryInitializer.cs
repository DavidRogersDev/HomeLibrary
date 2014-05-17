 using System;
using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.EF.Db
{
    //public class HomeLibraryInitializer : CreateDatabaseIfNotExists<HomeLibraryContext>
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            var johnKennedyToole = new Person
            {
                FirstName = "John",
                LastName = "Kennedy-Toole",
                Email = "john@dunces.com",
                IsAuthor = true,
                Sobriquet = "Troubled Genius"
            };

            var hunterSTompson = new Person
            {
                FirstName = "Hunter",
                LastName = "S. Tompson",
                Email = string.Empty,
                IsAuthor = true,
                Sobriquet = "Gonzo journo"
            };

            var terryHalpin =
                new Person
                {
                    FirstName = "Terry",
                    LastName = "Halpin",
                    Email = "terry@halpin.com",
                    IsAuthor = true,
                    Sobriquet = "ORM Guy"
                };

            var tonyMorgan =
                new Person
                {
                    FirstName = "Tony",
                    LastName = "Morgan",
                    Email = "tony@halpin.com",
                    IsAuthor = true,
                    Sobriquet = null
                };

            var alanTuring = new Person
            {
                FirstName = "Alan",
                LastName = "Turing",
                Email = "alan@turing.com",
                IsAuthor = false,
                Sobriquet = "Father of Awesome"
            };

            var edgarCodd = new Person
            {
                FirstName = "Edgar",
                LastName = "Codd",
                Email = "edgar@codd.com",
                IsAuthor = true,
                Sobriquet = "Father of Awesome"
            };

            context.People.AddRange(new List<Person> { johnKennedyToole, hunterSTompson, terryHalpin, tonyMorgan, alanTuring, edgarCodd });
            context.SaveChanges();

            var penguin = new Publisher {Name = "Penguin"};
            var morganKaufmann = new Publisher { Name = "Morgan Kaufmann" };

            context.Publishers.Add(penguin);
            context.Publishers.Add(morganKaufmann);
            context.SaveChanges();

            var aConfederacyOfDunces = new Book
            {
                Edition = Edition.First,
                Publisher = penguin,
                Title = "A Confederacy ofDunces",
                TypeOfBook = BookType.Novel,
                Authors = new List<Person> {johnKennedyToole}
            };

            var hellsAngels = new Book
            {
                Edition = Edition.First,
                Publisher = penguin,
                Title = "Hells Angels",
                TypeOfBook = BookType.Novel,
                Authors = new List<Person> {hunterSTompson}
            };

            var informationModelingAndRelationalDatabases = new Book
            {
                Edition = Edition.Second,
                Publisher = morganKaufmann,
                Title = "Information Modeling and Relational Databases",
                TypeOfBook = BookType.TextBook,
                Authors = new List<Person> { terryHalpin, tonyMorgan }
            };

            context.Books.AddRange(new List<Book> {aConfederacyOfDunces, hellsAngels, informationModelingAndRelationalDatabases });

            var lendingToTerry = new Lending {Book = aConfederacyOfDunces, DateLent = DateTime.Now};
            var lendingToAlan = new Lending { Book = hellsAngels, DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(90)) };

            context.Lendings.AddRange(new List<Lending> {lendingToTerry, lendingToAlan});

            terryHalpin.Lendings = new List<Lending> {lendingToTerry};
            alanTuring.Lendings = new List<Lending> {lendingToAlan};

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
