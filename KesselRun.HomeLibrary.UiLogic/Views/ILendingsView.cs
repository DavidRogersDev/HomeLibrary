using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface ILendingsView : IClosableView
    {
        LendingsViewModel Lendings { get; set; }

        event EventHandler AddLending;
        event EventHandler<LendingsViewEventArgs> ReloadView;


        void LoadAddLendingView(Type view);
    }
}