using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.Views.ViewModels
{
    public class AddLendingViewModel
    {
        public BindingList<Book> Books { get; set; }
        public BindingList<Person> People { get; set; }
    }
}
