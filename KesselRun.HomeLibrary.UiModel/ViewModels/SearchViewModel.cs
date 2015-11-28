using System.Collections.Generic;

namespace KesselRun.HomeLibrary.UiModel.ViewModels
{
    public abstract class SearchViewModel
    {
        protected SearchViewModel()
        {
            FilterMetaDataList = new List<FilterMetaData>();
            Operation = string.Empty;
        }

        public IList<FilterMetaData> FilterMetaDataList { get; set; }
        public string Operation { get; set; }
    }
}