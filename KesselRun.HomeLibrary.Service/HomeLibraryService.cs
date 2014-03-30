using System;
using System.ComponentModel;
using System.Linq;
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

        public HomeLibraryService()
        {
            mapper = new UniversalMapper(AutoMapper.Mapper.Engine);
        }

        public BindingList<UiModel.Models.Person> GetAllPeople()
        {
            var peopleRepository = _unitOfWork.People;
            var people = peopleRepository.GetAll();
            PaginatedList<Person> peoplePaginated = null;

            try
            {
                peoplePaginated = peopleRepository.Paginate(0, 3);
            }
            catch (Exception exception)
            {

            }

            var uiList = new BindingList<UiModel.Models.Person>();

            mapper.Map(peoplePaginated.AsQueryable(), uiList);

            return uiList;
        }

        public void Dispose()
        {
            //  This will be properly done in final code.
        }
    }
}
