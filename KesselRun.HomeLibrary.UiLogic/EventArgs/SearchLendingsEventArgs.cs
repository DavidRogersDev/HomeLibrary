
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class SearchLendingsEventArgs : LendingsViewEventArgs
    {
        public readonly IList<FilterMetaData> FilterMetaDataList;
        public readonly string FilterOperator;
        public readonly int SelectedLendingId;

        public SearchLendingsEventArgs(
            IList<FilterMetaData> filterMetaDataList, 
            string filterOperator, 
            int pageSize, 
            int pageIndex, 
            string sortBy, 
            ListSortDirection sortDirection, 
            int selectedLendingId) 
            : base(pageSize, pageIndex, sortBy, sortDirection)
        {
            FilterMetaDataList = filterMetaDataList;
            FilterOperator = filterOperator;
            SelectedLendingId = selectedLendingId;
        }
    }
}
