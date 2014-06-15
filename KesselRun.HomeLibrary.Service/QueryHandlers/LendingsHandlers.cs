using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Converters;
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
        private readonly Converter<string, Expression<Func<Model.Lending, string>>> _keySelector;

        public LendingsHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper, LendingsConverters keySelector)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _keySelector = keySelector.StringToPersonProperty;
        }

        public LendingsViewModel Handle(GetLendingsPagedSortedQuery query)
        {
            var lendingsViewModel = new LendingsViewModel();
             IList<Lending> lendings = new List<Lending>();
            int totalSize;
            var sortbySelector = _keySelector(query.SortBy);
                 
            foreach (var lending in _unitOfWork.Repository<Model.Lending>().Query()
                .Include(l => l.Borrower)
                .Include(l => l.Book.Authors)
                .OrderBy(q => q.OrderBy(sortbySelector))
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
