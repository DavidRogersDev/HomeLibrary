using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiModel.ViewModels
{
    public class LendingsViewModel
    {
        public BindingList<Lending> Lendings { get; set; }
        public PagerData PagerData { get; set; }
        public int SelectedGridLendingId { get; set; }
    }
}
