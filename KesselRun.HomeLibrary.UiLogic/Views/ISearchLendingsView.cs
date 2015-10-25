using System;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface ISearchLendingsView : IClosableView
    {
        //event EventHandler<SearchLendingsEventArgs> SearchLendings;
        event EventHandler SendSearchLendingsMessage;

        SearchLendingsViewModel SearchLendingsViewModel { get; set; }
    }
}
