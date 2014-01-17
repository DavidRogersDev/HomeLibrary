using System.Data.Entity;

namespace KesselRun.HomeLibrary.Model.Db
{
    public class HomeLibraryContext : DbContext
    {
        //  DbSets go here
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  set up the Publisher's table
            modelBuilder.Entity<Publisher>().Property(p => p.Name).HasMaxLength(50).IsRequired().IsVariableLength();
            
            //  set up the People table
            modelBuilder.Entity<Person>().Property(p => p.Email).HasMaxLength(50).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(30).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(30).IsRequired().IsVariableLength();
            modelBuilder.Entity<Person>().Property(p => p.Sobriquet).HasMaxLength(30).IsOptional().IsVariableLength();

            //  set up the Comment table
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).HasMaxLength(null).IsRequired().IsVariableLength();

            //  set up the Book table
            modelBuilder.Entity<Book>().Property(c => c.Title).HasMaxLength(300).IsRequired().IsVariableLength();


            base.OnModelCreating(modelBuilder);
        }
    }
}
