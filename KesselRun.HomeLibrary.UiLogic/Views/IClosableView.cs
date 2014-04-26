using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IClosableView : IView
    {
        event EventHandler ViewClosing;
        event EventHandler CloseControl;

        void CloseView();
        void LogEventToView(LogEvent logEvent);
    }
}