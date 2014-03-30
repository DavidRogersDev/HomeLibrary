using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Services
{
    public interface IWindow
    {
        void ShowChildView(Type view);
    }
}