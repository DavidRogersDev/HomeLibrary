using System;
using System.ComponentModel;
using System.Linq;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.Service
{
    public class HomeLibraryService : IHomeLibraryService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;


        public HomeLibraryService(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public BindingList<UiModel.Models.Person> GetAllPeople()
        {
            var peopleRepository = _unitOfWork.People;
            PaginatedList<Person> peoplePaginated = null;

            peoplePaginated = peopleRepository.Paginate(0, 3);

            var uiList = new BindingList<UiModel.Models.Person>();

            _mapper.Map(peoplePaginated.AsQueryable(), uiList);

            return uiList;
        }

        public void Dispose()
        {
            //  This will be properly done in final code.
        }
    }
}
