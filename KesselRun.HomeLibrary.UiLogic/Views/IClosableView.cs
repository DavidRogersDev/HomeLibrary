using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IClosableView : IView
    {
        event EventHandler ViewClosing;
        event EventHandler Close;

        void CloseView();
        void ReleasePresenter(IPresenter presenter);
    }
}