
using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class LendingsViewEventArgs : System.EventArgs
    {
        public readonly int PageSize;
        public readonly int PageIndex;
        public readonly string SortBy;
        public readonly ListSortDirection SortDirection;

        public LendingsViewEventArgs(int pageSize, int pageIndex, string sortBy, ListSortDirection sortDirection)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
    }
}
