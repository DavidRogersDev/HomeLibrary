using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiModel.ViewModels
{
    public class PeopleViewModel
    {
        public BindingList<Person> People { get; set; }
        public PagerData PagerData { get; set; }

    }
}
