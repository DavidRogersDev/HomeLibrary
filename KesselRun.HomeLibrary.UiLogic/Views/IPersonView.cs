using System;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IPersonView : IView
    {
        event EventHandler ViewClosing;
        event EventHandler EditPersonClicked;

        PersonViewModel ViewModel { get; set; }
        void ReleasePresenter(IPresenter presenter);
    }
}