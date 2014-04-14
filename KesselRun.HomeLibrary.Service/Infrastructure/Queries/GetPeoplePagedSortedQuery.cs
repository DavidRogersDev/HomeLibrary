using System.Collections.Generic;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Infrastructure.Queries
{
    public class GetPeoplePagedSortedQuery : IQuery<IList<Person>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
