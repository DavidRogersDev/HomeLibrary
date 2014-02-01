using System;
using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.EF.Db
{
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;

            var johnKennedyToole = new Person
                {
                    FirstName = "John",
                    LastName = "Kennedy-Toole",
                    Email = "john@dunces.com",
                    IsAuthor = true,
                    Sobriquet = "Troubled Genius"
                };

            context.People.Add(johnKennedyToole);
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

            context.Books.Add(aConfederacyOfDunces);

            var lending = new Lending {Book = aConfederacyOfDunces, DateLent = DateTime.Now};

            context.Lendings.Add(lending);

            var listOfPeople = new List<Person>
                {
                    new Person
                        {
                            FirstName = "Terry",
                            LastName = "Halpin",
                            Email = "terry@halpin.com",
                            IsAuthor = true,
                            Lendings = new List<Lending> {lending},
                            Sobriquet = "ORM Guy"
                        },
                    new Person
                        {
                            FirstName = "Alan",
                            LastName = "Turing",
                            Email = "alan@turing.com",
                            IsAuthor = false,
                            Sobriquet = "Father of Awesome"
                        }
                    ,
                };

            listOfPeople.ForEach(p => context.People.Add(p));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
