using System;
using KesselRun.HomeLibrary.UiModel.ViewModels;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IMainView : IClosableView
    {
        MainViewModel MainViewModel { get; set; }
        void ShowChildView(Type view);
    }
}