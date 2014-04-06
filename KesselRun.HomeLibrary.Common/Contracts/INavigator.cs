using System;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Common.Contracts
{
    public interface INavigator
    {
        void NavigateTo(Type view, Control containerControl);
    }
}
