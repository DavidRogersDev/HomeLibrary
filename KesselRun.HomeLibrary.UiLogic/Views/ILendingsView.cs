using System;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface ILendingsView : IClosableView
    {
        BindingList<Lending> Lendings { get; set; }

        event EventHandler AddLending;
        event EventHandler<LendingsViewEventArgs> ReloadView;


        void LoadAddLendingView(Type view);
    }
}