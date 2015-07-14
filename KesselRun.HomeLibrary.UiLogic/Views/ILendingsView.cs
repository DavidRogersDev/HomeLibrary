using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface ILendingsView : IClosableView
    {
        LendingsViewModel LendingsViewModel { get; set; }

        event EventHandler AddLending;
        event EventHandler AddPerson;
        event EventHandler<SearchLendingsEventArgs> ReloadView;


        void LoadAddLendingView(Type view);
        void LoadAddPersonView(Type view);
    }
}