using KesselRun.HomeLibrary.UiLogic.EventArgs;
using System;

namespace KesselRun.HomeLibrary.UiLogic.Views
{
    public interface IAddPersonView : IClosableView
    {
        event EventHandler<AddPersonEventArgs> AddNewPerson;
    }
}
