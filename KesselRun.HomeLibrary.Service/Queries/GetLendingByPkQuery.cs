
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetLendingByPkQuery : IQuery<Lending>
    {
        public int Id { get; set; }
    }
}
