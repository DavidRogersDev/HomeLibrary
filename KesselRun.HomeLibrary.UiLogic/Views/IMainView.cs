using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IMainView : IClosableView, IBaseView
    {
        event EventHandler NavigateToLendingsView;
        event EventHandler NavigateToPeopleView;

        MainViewModel MainViewModel { get; set; }
        LendingsViewModel LendingsViewModel { get; set; }
        void ShowChildView(Type view);
    }
}