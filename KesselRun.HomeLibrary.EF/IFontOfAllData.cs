using System.Collections.Generic;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF
{
    public interface IFontOfAllData
    {
        IList<Lending> GetAllLendingsPagedAndSorted(int pageNr, int pageSize);
    }
}
