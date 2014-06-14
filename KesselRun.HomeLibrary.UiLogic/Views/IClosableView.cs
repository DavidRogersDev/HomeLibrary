using System;
using KesselRun.HomeLibrary.UiModel;
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