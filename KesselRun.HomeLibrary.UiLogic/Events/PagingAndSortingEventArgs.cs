using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiLogic.Events
{
    public class PagingAndSortingEventArgs : PagingEventArgs
    {
        public string SortBy;
        public ListSortDirection SortDirection;

        public PagingAndSortingEventArgs(string sortBy, ListSortDirection sortDirection, int pageIndex, int pageSize, int pageCount)
            : base(pageIndex, pageSize, pageCount)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
    }
}