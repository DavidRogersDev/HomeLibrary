using System.ComponentModel;
using KesselRun.HomeLibrary.UiLogic.Enums;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.Views.ViewModels
{
    public class PersonViewModel
    {
        public BindingList<Person> People { get; set; }
        public FilterType SearchFilter { get; set; }
    }
}