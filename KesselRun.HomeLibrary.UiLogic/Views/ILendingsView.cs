using System.Collections.ObjectModel;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface ILendingsView : IClosableView
    {
        BindingList<Lending> Lendings { get; set; }
    }
}