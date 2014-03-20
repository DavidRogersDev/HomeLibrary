using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.Service
{
    public class HomeLibraryService : IHomeLibraryService, IDisposable
    {
        readonly UnitOfWork _unitOfWork = new UnitOfWork(new RepositoryProvider(new RepositoryFactories()));
        private readonly UniversalMapper mapper;
        private readonly Converter<string, Expression<Func<Person, string>>> keySelector;

        public HomeLibraryService()
        {
            mapper = new UniversalMapper(AutoMapper.Mapper.Engine);
            keySelector = StringToPersonProperty;
        }

        public BindingList<UiModel.Models.Person> GetPeoplePaged(int pageIndex, int pageSize)
        {
            var people = _unitOfWork.People.Paginate(pageIndex, pageSize);

            var uiList = new BindingList<UiModel.Models.Person>();

            mapper.Map(people.AsQueryable(), uiList);

            return uiList;
        }

        public BindingList<UiModel.Models.Person> GetPeoplePagedAndSorted(int pageIndex, int pageSize, string sortBy, ListSortDirection sortDirection)
        {
            IList<Person> people;

            switch (sortDirection)
            {
                case ListSortDirection.Ascending:
                    people = _unitOfWork.People.Paginate(pageIndex, pageSize, StringToPersonProperty(sortBy));
                    break;
                default:
                    people = _unitOfWork.People.PaginateDescending(pageIndex, pageSize, keySelector(sortBy));
                    break;
            }

            var uiList = new BindingList<UiModel.Models.Person>();

            mapper.Map(people.AsQueryable(), uiList);

            return uiList;
        }

        public BindingList<UiModel.Models.Person> GetAllPeople()
        {
            var pr = _unitOfWork.People;
            var people = pr.GetAll();
            PaginatedList<Person> pp = null;

            try
            {
                pp = pr.Paginate(0, 3);
            }
            catch (Exception exception)
            {

            }

            var uiList = new BindingList<UiModel.Models.Person>();

            mapper.Map(pp.AsQueryable(), uiList);

            return uiList;
        }

        private Expression<Func<Person, string>> StringToPersonProperty(string column)
        {
            switch (column)
            {
                case "LastName":
                    return p => p.LastName;
                case "FirstName":
                    return p => p.FirstName;
            }

            return null;
        }

        public void Dispose()
        {
            //  This will be properly done in final code.
            var bla = string.Empty;
        }
    }
}
