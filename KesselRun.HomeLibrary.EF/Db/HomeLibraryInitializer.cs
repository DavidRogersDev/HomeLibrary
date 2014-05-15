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

            var hunterS = new Person
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
            var alanTuring = new Person
            {
                FirstName = "Alan",
                LastName = "Turing",
                Email = "alan@turing.com",
                IsAuthor = false,
                Sobriquet = "Father of Awesome"
            };

            context.People.AddRange(new List<Person> {johnKennedyToole, hunterS, terryHalpin, alanTuring});
            context.SaveChanges();

            var penguin = new Publisher {Name = "Penguin"};

            context.Publishers.Add(penguin);
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
                Authors = new List<Person> {hunterS}
            };

            context.Books.AddRange(new List<Book> {aConfederacyOfDunces, hellsAngels});

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
