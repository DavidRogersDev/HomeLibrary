using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Db
{
    public class HomeLibraryContext : EntitiesContext
    {
        public HomeLibraryContext()
        {
        }

        //  DbSets go here
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  set up the Book table
            modelBuilder.Entity<Book>().HasKey(p => p.Id);
            modelBuilder.Entity<Book>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Book>().Property(c => c.Title).IsRequired().IsVariableLength();
            modelBuilder.Entity<Book>().Ignore(p => p.State);
            modelBuilder.Entity<Book>().Ignore(p => p.OriginalValues);

            //  set up the BookCover table
            modelBuilder.Entity<BookCover>().HasKey(p => p.Id);
            modelBuilder.Entity<BookCover>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BookCover>().Ignore(p => p.State);
            modelBuilder.Entity<BookCover>().Ignore(p => p.OriginalValues);

            //  set up the Comment table
            modelBuilder.Entity<Comment>().HasKey(p => p.Id);
            modelBuilder.Entity<Comment>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).IsRequired().IsVariableLength();
            modelBuilder.Entity<Comment>().Ignore(p => p.State);
            modelBuilder.Entity<Comment>().Ignore(p => p.OriginalValues);

            //  set up the Lending table
            modelBuilder.Entity<Lending>().HasKey(p => p.Id);
            modelBuilder.Entity<Lending>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Lending>().Ignore(p => p.State);
            modelBuilder.Entity<Lending>().Ignore(p => p.OriginalValues);

            //  set up the People table
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Person>().Property(p => p.Email).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.Sobriquet).IsOptional().IsVariableLength();
            modelBuilder.Entity<Person>().Ignore(p => p.State);
            modelBuilder.Entity<Person>().Ignore(p => p.OriginalValues);

            //  set up the Publisher's table
            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Publisher>().Property(p => p.Name).IsRequired().IsVariableLength();
            modelBuilder.Entity<Publisher>().Ignore(p => p.State);
            modelBuilder.Entity<Publisher>().Ignore(p => p.OriginalValues);

            base.OnModelCreating(modelBuilder);
        }

        private Dictionary<string, object> BuildOriginalValues(DbPropertyValues originalValues)
        {
            var result = new Dictionary<string, object>();

            foreach (var propertyName in originalValues.PropertyNames)
            {
                var value = originalValues[propertyName];

                if (value is DbPropertyValues)
                {
                    result[propertyName] = BuildOriginalValues((DbPropertyValues)value);
                }
                else
                {
                    result[propertyName] = value;
                }
            }
            return result;
        }
    }
}
