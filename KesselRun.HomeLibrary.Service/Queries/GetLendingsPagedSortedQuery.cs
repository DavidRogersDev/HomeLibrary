using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetLendingsPagedSortedQuery : IQuery<LendingsViewModel>
    {
        [Range(0, 100, ErrorMessage = "The Page Number cannot be less than 1.")]
        public ListSortDirection OrderByDirection { get; set; }
        public string Filter { get; set; }
        public string FilterBy { get; set; }
        public string FilterOperation { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }

        public int SelectedLendingId { get; set; }
    }
}
