
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class AddPersonEventArgs : System.EventArgs
    {
        public readonly Person Person;

        public AddPersonEventArgs(Person person)
        {
            Person = person;
        }
    }
}
