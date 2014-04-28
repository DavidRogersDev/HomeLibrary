 using System;
using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.EF.Db
{
    public class HomeLibraryInitializer : CreateDatabaseIfNotExists<HomeLibraryContext>
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    //public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
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

            context.People.AddRange(new List<Person> { johnKennedyToole, hunterS });
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
                    Authors = new List<Person> { johnKennedyToole }
                };

            var hellsAngels = new Book
            {
                Edition = Edition.First,
                Publisher = penguin,
                Title = "Hells Angels",
                TypeOfBook = BookType.Novel,
                Authors = new List<Person> { hunterS }
            };

            context.Books.AddRange(new List<Book> {aConfederacyOfDunces, hellsAngels});

            var lending = new Lending { Book = aConfederacyOfDunces, DateLent = DateTime.Now };
            var lending2 = new Lending { Book = hellsAngels, DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(90)) };

            context.Lendings.AddRange(new List<Lending>{ lending, lending2 });

            var listOfPeople = new List<Person>
                {
                    new Person
                        {
                            FirstName = "Terry",
                            LastName = "Halpin",
                            Email = "terry@halpin.com",
                            IsAuthor = true,
                            Lendings = new List<Lending> { lending },
                            Sobriquet = "ORM Guy"
                        },
                    new Person
                        {
                            FirstName = "Alan",
                            LastName = "Turing",
                            Email = "alan@turing.com",
                            IsAuthor = false,
                            Lendings = new List<Lending> { lending2 },
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
