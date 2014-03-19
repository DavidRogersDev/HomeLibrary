using System.ComponentModel;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service
{
    public interface IHomeLibraryService
    {
        BindingList<Person> GetPeoplePaged(int pageIndex, int pageSize);
        BindingList<Person> GetPeoplePagedAndSorted(int pageIndex, int pageSize, string sortBy, ListSortDirection sortDirection);
        BindingList<Person> GetAllPeople();
    }
}