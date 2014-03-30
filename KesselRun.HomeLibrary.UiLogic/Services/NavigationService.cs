using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.Common.Contracts;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Services
{
    public class NavigationService : INavigationService
    {
        private IWindow _window;

        public NavigationService(IWindow window)
        {
            _window = window;
        }

        public void NavigateToView(Type view)
        {
            _window.ShowChildView(view);
        }
    }
}
