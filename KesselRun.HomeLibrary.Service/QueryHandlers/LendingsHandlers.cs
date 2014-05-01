using System.Collections.Generic;
using System.Linq;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class LendingsHandlers : 
        IQueryHandler<GetLendingsPagedSortedQuery, IList<Lending>>,
        IQueryHandler<GetLendingByPkQuery, Lending>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public LendingsHandlers(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<Lending> Handle(GetLendingsPagedSortedQuery query)
        {
             IList<Lending> lendings = new List<Lending>();

             foreach (var lending in _unitOfWork.Lendings.Paginate(query.PageNr, query.PageSize, l => l.Id, l => true, l => l.Book.Authors, l => l.Borrower ))
             {
                 var uiLending = new Lending();
                 lendings.Add(_mapper.Map(lending, uiLending));
             }
            
            return lendings;
        }

        public Lending Handle(GetLendingByPkQuery queryObject)
        {
            var uiLending = new Lending();
            return _mapper.Map(_unitOfWork.Lendings.FindBy(l => l.Id == queryObject.Id).Single(), uiLending);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
