﻿using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class SearchPeopleEventArgs : GridSearchEventArgs
    {
        public SearchPeopleEventArgs(
            IList<FilterMetaData> filterMetaDataList,
            string filterOperator,
            int pageSize, 
            int pageIndex, 
            string sortBy, 
            ListSortDirection sortDirection)
            : base(filterMetaDataList, filterOperator, pageSize, pageIndex, sortBy, sortDirection)
        {
        }
    }
}