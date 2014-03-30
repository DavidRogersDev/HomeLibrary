using System;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.Common.Contracts
{
    public interface INavigationService
    {
        void NavigateToView(Type view);
    }
}
