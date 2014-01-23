using System;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories.Contracts;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF.Repositories
{
    public class BookRepository : RepositoryBase<Book, HomeLibraryContext>, IBookRepository 
    {
        public BookRepository()
        {
            
        }

        public BookRepository(HomeLibraryContext ctx) 
            : base(ctx)
        {
            
        }

        public override void CheckDisposed()
        {
            if (Context == null)
            {
                throw new ObjectDisposedException("BookRepository");
            }
        }
    }
}
