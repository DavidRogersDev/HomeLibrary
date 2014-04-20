using System.Collections.Generic;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Queries
{
    public class GetPeoplePagedSortedQueryHandler : IQueryHandler<GetPeoplePagedSortedQuery, IList<Person>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public GetPeoplePagedSortedQueryHandler(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<Person> Handle(GetPeoplePagedSortedQuery query)
        {
            IList<Person> people = new List<Person>();

            foreach (var person in _unitOfWork.People.Paginate(query.PageNr, query.PageSize, p => p.Id, p => true, p => p.Books))
            {
                var uiPerson = new Person();
                people.Add(_mapper.Map(person, uiPerson));
            }
            return people;
        }
    }
}
