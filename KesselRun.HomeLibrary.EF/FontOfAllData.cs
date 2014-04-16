using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF
{
    public class FontOfAllData : IFontOfAllData
    {
        private readonly HomeLibraryContext _context;

        public FontOfAllData(HomeLibraryContext context)
        {
            _context = context;
        }

        public IList<Lending> GetAllLendingsPagedAndSorted(int pageNr, int pageSize)
        {
            return _context.Lendings.Include(l => l.Book.Authors)
                .Include(l => l.Borrower)
                .OrderBy(l => l.Id)
                .Skip(pageNr*pageSize)
                .Take(pageSize).ToList();
        }
    }
}