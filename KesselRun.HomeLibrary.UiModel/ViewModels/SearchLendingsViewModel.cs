
using System.Collections.Generic;

namespace KesselRun.HomeLibrary.UiModel.ViewModels
{
    public class SearchLendingsViewModel
    {
        public SearchLendingsViewModel()
        {
            FilterMetaDataList = new List<FilterMetaData>();
            Operation = string.Empty;
        }

        public IList<FilterMetaData> FilterMetaDataList { get; set; }
        public string Operation { get; set; }
        public int SelectedGridLendingId { get; set; }
    }

    public struct FilterMetaData
    {
        public string FilterBy { get; set; }
        public string FilterValue { get; set; }
    }
}
