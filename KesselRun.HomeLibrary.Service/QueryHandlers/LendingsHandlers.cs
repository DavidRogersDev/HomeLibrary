using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class LendingsHandlers : 
        IQueryHandler<GetLendingsPagedSortedQuery, LendingsViewModel>,
        IQueryHandler<GetLendingByPkQuery, Lending>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public LendingsHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public LendingsViewModel Handle(GetLendingsPagedSortedQuery query)
        {
            var lendingsViewModel = new LendingsViewModel();
             IList<Lending> lendings = new List<Lending>();
            int totalSize;
                 
            foreach (var lending in _unitOfWork.Repository<Model.Lending>().Query()
                .Include(l => l.Borrower)
                .Include(l => l.Book.Authors)
                .OrderBy(q => q.OrderBy(lending => lending.Id))
                .SelectPage(query.PageNr, query.PageSize, out totalSize))
             {
                 var uiLending = new Lending();
                 lendings.Add(_mapper.Map(lending, uiLending));
             }

            lendingsViewModel.Lendings = new BindingList<Lending>(lendings);
            lendingsViewModel.NumberOfPages = (totalSize / query.PageSize) + 1;
            return lendingsViewModel;
        }

        public Lending Handle(GetLendingByPkQuery queryObject)
        {
            var uiLending = new Lending();
            return _mapper.Map(_unitOfWork.Repository<Model.Lending>().Find(queryObject.Id), uiLending);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
