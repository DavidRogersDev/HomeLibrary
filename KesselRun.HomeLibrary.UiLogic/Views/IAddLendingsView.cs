using System;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IAddLendingsView : IClosableView
    {
        event EventHandler<AddLendingEventArgs> AddNewLending;

        AddLendingViewModel AddLendingViewModel { get; set; }

        void AddLending(int bookId, int borrowerId, DateTime dateLent, DateTime? dateDue);
    }
}
