using System.Collections.Generic;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service
{
    public interface ILendingsService
    {
        IList<Lending> GetLendings();
    }
}