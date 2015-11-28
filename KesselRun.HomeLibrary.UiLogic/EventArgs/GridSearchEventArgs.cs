using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class GridSearchEventArgs : PagingViewEventArgs
    {
        public readonly IList<FilterMetaData> FilterMetaDataList;
        public readonly string FilterOperator;

        public GridSearchEventArgs(IList<FilterMetaData> filterMetaDataList, string filterOperator, int pageSize, int pageIndex, string sortBy, ListSortDirection sortDirection)
            : base(pageSize, pageIndex, sortBy, sortDirection)
        {
            FilterMetaDataList = filterMetaDataList;
            FilterOperator = filterOperator;
        }
    }
}
