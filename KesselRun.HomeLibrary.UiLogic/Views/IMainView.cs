using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IMainView : IClosableView
    {
        void ShowChildView(Type view);
    }
}