using System.Collections.Generic;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetPeopleSortedQuery : IQuery<IList<Person>>
    {
        public string SortBy { get; set; }
    }
}
