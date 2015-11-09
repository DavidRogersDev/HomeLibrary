using System.ComponentModel;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface IPageCapbable
    {
        ListSortDirection OrderByDirection { get; set; }

        int PageIndex { get; set; }
        int PageSize { get; set; }
        string SortBy { get; set; }
    }
}
