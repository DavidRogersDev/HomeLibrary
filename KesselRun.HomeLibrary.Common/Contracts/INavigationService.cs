using System;
using System.Windows.Forms;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.Common.Contracts
{
    public interface INavigationService
    {
        void NavigateTo(Type view, Control containerControl);
    }
}
