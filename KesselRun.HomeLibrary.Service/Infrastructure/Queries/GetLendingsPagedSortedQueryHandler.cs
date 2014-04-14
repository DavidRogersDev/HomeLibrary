using System.Collections.Generic;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Infrastructure.Queries
{
    public class GetLendingsPagedSortedQueryHandler : IQueryHandler<GetLendingsPagedSortedQuery, IList<Lending>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public GetLendingsPagedSortedQueryHandler(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<Lending> Handle(GetLendingsPagedSortedQuery query)
        {
             IList<Lending> lendings = new List<Lending>();

             foreach (var lending in _unitOfWork.Lendings.Paginate(query.PageNr, query.PageSize, l => l.Id, l => true, l => l.Book.Authors, l => l.Borrower))
             {
                 var uiLending = new Lending();
                 lendings.Add(_mapper.Map(lending, uiLending));
             }

            return lendings;
        }
    }
}
