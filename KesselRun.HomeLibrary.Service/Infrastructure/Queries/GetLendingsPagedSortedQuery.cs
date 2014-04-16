using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Infrastructure.Queries
{
    public class GetLendingsPagedSortedQuery : IQuery<IList<Lending>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
