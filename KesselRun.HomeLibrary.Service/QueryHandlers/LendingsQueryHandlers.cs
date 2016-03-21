using AutoMapper;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class LendingsQueryHandlers :
        IQueryHandler<GetLendingsPagedSortedQuery, LendingsViewModel>,
        IQueryHandler<GetLendingByPkQuery, Lending>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;
        private bool _disposed = false;

        public LendingsQueryHandlers(IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public LendingsViewModel Handle(GetLendingsPagedSortedQuery query)
        {
            var lendingsViewModel = new LendingsViewModel {PagerData = new PagerData()};
            IList<LendingGridItem> lendings = new List<LendingGridItem>();
            Expression<Func<Model.Lending, bool>> filterFunc = GetFilterFunc(query);
            Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> orderByFunc = GetOrderByFunc<Model.Lending>(query);
            var lendsingsRepository = _unitOfWork.Repository<Model.Lending>();

            int totalSize = lendsingsRepository.Query().Select().Count();

            PagerHelper.ProcessPagingData(query, lendingsViewModel.PagerData, totalSize);

            foreach (var lending in _unitOfWork.Repository<Model.Lending>().Query(filterFunc)
                .Include(l => l.Borrower)
                .Include(l => l.Book.Authors)
                .OrderBy(orderByFunc)
                .SelectPage(query.PageIndex, query.PageSize, out totalSize))
            {
                var uiLending = new LendingGridItem();
                lendings.Add(_mapper.Map(lending, uiLending));
            }

            lendingsViewModel.Lendings = new BindingList<LendingGridItem>(lendings);
            
            return lendingsViewModel;
        }

        private Expression<Func<Model.Lending, bool>> GetFilterFunc(GetLendingsPagedSortedQuery query)
        {
            if (!query.Filters.Any())
                return null;
            
            return ExpressionBuilder.GetExpression<Model.Lending>(query.Filters);
        }

        private Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderByFunc<T>(
            GetLendingsPagedSortedQuery query)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");

            var memberExpression = ExpressionBuilder.GetMember(param, query.SortBy);

            return ExpressionBuilder.GetExpressionSortFunc<T>(param, memberExpression, query.OrderByDirection);
        }

        //private Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> GetOrderByFuncForStrings(
        //    GetLendingsPagedSortedQuery query)
        //{
        //    switch (query.OrderByDirection)
        //    {
        //        case ListSortDirection.Ascending:
        //            return l => l.OrderBy(_keySelectors.StringToStringProperty(query.SortBy));
        //        case ListSortDirection.Descending:
        //            return l => l.OrderByDescending(_keySelectors.StringToStringProperty(query.SortBy));
        //    }

        //    return null;
        //}

        //private Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> GetOrderByFuncForDates(
        //    GetLendingsPagedSortedQuery query)
        //{
        //    switch (query.OrderByDirection)
        //    {
        //        case ListSortDirection.Ascending:
        //            return l => l.OrderBy(_keySelectors.StringToDateTimeProperty(query.SortBy));
        //        case ListSortDirection.Descending:
        //            return l => l.OrderByDescending(_keySelectors.StringToDateTimeProperty(query.SortBy));
        //    }

        //    return null;
        //}

        public Lending Handle(GetLendingByPkQuery queryObject)
        {
            var uiLending = new Lending();
            return _mapper.Map(_unitOfWork.Repository<Model.Lending>().Find(queryObject.Id), uiLending);
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
                //_mapper.Dispose();
            }

            _disposed = true;
        }
    }
}
