using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class SearchLendingsEventArgs : GridSearchEventArgs 
    {
        public readonly int SelectedLendingId;

        public SearchLendingsEventArgs(
            IList<FilterMetaData> filterMetaDataList, 
            string filterOperator, 
            int pageSize, 
            int pageIndex, 
            string sortBy, 
            ListSortDirection sortDirection, 
            int selectedLendingId) 
            : base(filterMetaDataList, filterOperator, pageSize, pageIndex, sortBy, sortDirection)
        {
            SelectedLendingId = selectedLendingId;
        }
    }
}
