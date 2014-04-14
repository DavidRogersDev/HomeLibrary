using System.Collections.ObjectModel;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.Views.ViewModels
{
    public class LendingsViewModel
    {
        public BindingList<Lending> Lendings { get; set; }
    }
}
