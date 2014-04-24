using System;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IMainView : IClosableView
    {
        MainViewModel MainViewModel { get; set; }

        void ShowChildView(Type view);
    }
}