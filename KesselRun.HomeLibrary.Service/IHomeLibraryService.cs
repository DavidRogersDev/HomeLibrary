using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service
{
    public interface IHomeLibraryService
    {
        BindingList<Person> GetAllPeople();
    }
}