using System;

namespace KesselRun.HomeLibrary.Common.Contracts
{
    public interface IStackableView
    {
        Type NavigationSource { get; set; }
    }
}