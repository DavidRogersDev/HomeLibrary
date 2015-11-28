using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IPeopleView : IClosableView
    {
        PeopleViewModel PeopleViewModel { get; set; }
        event EventHandler<SearchPeopleEventArgs> ReloadView;
    }
}
