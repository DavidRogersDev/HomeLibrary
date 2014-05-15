using System.Collections.Generic;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetBooksSorted : IQuery<IList<Book>>
    {
        public string SortBy { get; set; }
    }
}
