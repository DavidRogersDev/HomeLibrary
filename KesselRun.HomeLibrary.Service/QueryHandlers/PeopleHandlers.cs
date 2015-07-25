using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class PeopleHandlers : IQueryHandler<GetPeopleSortedQuery, IList<Person>>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUniversalMapper _mapper;
        private bool _disposed = false;

        public PeopleHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<Person> Handle(GetPeopleSortedQuery query)
        {
            IList<Person> people = new List<Person>();

            foreach (var person in _unitOfWork.Repository<Model.Person>().Query().Select())
            {
                var uiPerson = new Person();
                people.Add(_mapper.Map(person, uiPerson));
            }

            return people.OrderBy(o => o.Id).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _unitOfWork.Dispose();
                _mapper.Dispose();
            }

            _disposed = true;
        }
    }
}
