using System.Collections.Generic;
using KesselRun.HomeLibrary.EF.Enums;

namespace KesselRun.HomeLibrary.EF.Contracts
{
    public interface IObjectWithState
    {
        State State { get; set; }
        Dictionary<string, object> OriginalValues { get; set; }
    }
}
