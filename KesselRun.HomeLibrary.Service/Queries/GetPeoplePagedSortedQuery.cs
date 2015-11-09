using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetPeoplePagedSortedQuery : IQuery<PeopleViewModel>, IPageCapbable
    {
        public ListSortDirection OrderByDirection { get; set; }
        public IList<Filter> Filters { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
    }
}
