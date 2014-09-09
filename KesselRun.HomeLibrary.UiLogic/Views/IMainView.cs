using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IMainView : IClosableView
    {
        //event EventHandler<SearchLendingsEventArgs> SearchLendings;

        MainViewModel MainViewModel { get; set; }
        LendingsViewModel LendingsViewModel { get; set; }
        void ShowChildView(Type view);
    }
}