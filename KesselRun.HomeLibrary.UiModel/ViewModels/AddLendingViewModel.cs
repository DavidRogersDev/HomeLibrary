using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiModel.ViewModels
{
    public class AddLendingViewModel
    {
        public BindingList<Book> Books { get; set; }
        public BindingList<Person> People { get; set; }
    }
}
