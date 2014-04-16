using System.Collections.Generic;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.Infrastructure.Queries
{
    public class GetLendingsPagedSortedQueryHandler : IQueryHandler<GetLendingsPagedSortedQuery, IList<Lending>>
    {
        private readonly IFontOfAllData _fontOfAllData;
        private readonly IUniversalMapper _mapper;

        public GetLendingsPagedSortedQueryHandler(IFontOfAllData fontOfAllData, IUniversalMapper mapper)
        {
            _fontOfAllData = fontOfAllData;
            _mapper = mapper;
        }

        public IList<Lending> Handle(GetLendingsPagedSortedQuery query)
        {
             IList<Lending> lendings = new List<Lending>();

             foreach (var lending in _fontOfAllData.GetAllLendingsPagedAndSorted(query.PageNr, query.PageSize))
             {
                 var uiLending = new Lending();
                 lendings.Add(_mapper.Map(lending, uiLending));
             }

            return lendings;
        }
    }
}
