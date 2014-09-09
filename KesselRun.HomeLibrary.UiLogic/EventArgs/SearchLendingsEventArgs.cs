
using System.ComponentModel;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class SearchLendingsEventArgs : LendingsViewEventArgs
    {
        public readonly string Filter;
        public readonly string FilterBy;
        public readonly string FilterOperator;

        public SearchLendingsEventArgs(string filter, string filterBy, string filterOperator, int pageSize, int pageIndex, string sortBy, ListSortDirection sortDirection) 
            : base(pageSize, pageIndex, sortBy, sortDirection)
        {
            Filter = filter;
            FilterBy = filterBy;
            FilterOperator = filterOperator;
        }
    }
}
