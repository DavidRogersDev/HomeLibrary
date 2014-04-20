using System.Collections.Generic;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetLendingsPagedSortedQuery : IQuery<IList<Lending>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
