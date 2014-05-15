using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetLendingsPagedSortedQuery : IQuery<IList<Lending>>
    {
        [Range(0, 100, ErrorMessage = "The Page Number cannot be less than 1.")]
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}
