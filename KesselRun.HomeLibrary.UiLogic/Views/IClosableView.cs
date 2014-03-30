using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IClosableView : IView
    {
        event EventHandler ViewClosing;

        void CloseView();
        void ReleasePresenter(IPresenter presenter);
    }
}