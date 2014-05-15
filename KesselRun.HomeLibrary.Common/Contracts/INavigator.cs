using System;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Common.Contracts
{
    public interface INavigator
    {
        void ClearAll();
        void ClearContainer(Control containerControl);
        void Navigate(Type fromView, Type toView, Control containerControl);
        void NavigateTo(Type view, Control containerControl);
        Control NavigationRootControl { get; set; }
        void Return(Control containerControl);
    }
}
