using System.Collections.Generic;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.Model.Contracts
{
    public interface IObjectWithState
    {
        State State { get; set; }
        Dictionary<string, object> OriginalValues { get; set; }
    }
}
