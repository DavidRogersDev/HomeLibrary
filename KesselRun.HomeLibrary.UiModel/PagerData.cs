using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiModel
{
    public class PagerData
    {
        public int NumberOfPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ListSortDirection SortOrder { get; set; }
        public string SortByField { get; set; }
    }
}
