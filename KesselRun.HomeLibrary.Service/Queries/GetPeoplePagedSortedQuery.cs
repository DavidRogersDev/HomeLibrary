using System.Collections.Generic;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetPeoplePagedSortedQuery : IQuery<IList<Person>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
