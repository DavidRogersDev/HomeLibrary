using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetPeopleSortedQuery : IQuery<IList<Person>>
    {
        public IList<Filter> Filters { get; set; }
        public ListSortDirection OrderByDirection { get; set; }
        public string SortBy { get; set; }
    }
}
