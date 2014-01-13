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
            base.OnModelCreating(modelBuilder);
        }
    }
}
