using KesselRun.HomeLibrary.Mapper.Mappers;
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
        private readonly IUniversalMapper _mapper;
        private bool _disposed = false;

        public LendingsQueryHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public LendingsViewModel Handle(GetLendingsPagedSortedQuery query)
        {
            var lendingsViewModel = new LendingsViewModel {PagerData = new PagerData()};
            IList<Lending> lendings = new List<Lending>();
            Expression<Func<Model.Lending, bool>> filterFunc = GetFilterFunc(query);
            Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> orderByFunc = GetOrderByFunc<Model.Lending>(query);
            var lendsingsRepository = _unitOfWork.Repository<Model.Lending>();

            int totalSize = lendsingsRepository.Query().Select().Count();

            var pageCount = totalSize/query.PageSize;
            var remainder = totalSize%query.PageSize;

            if (query.PageIndex > pageCount)
            {
                if (remainder > 0)
                {
                    if (remainder <= totalSize)
                    {
                        query.PageIndex = ++pageCount;
                    }
                }
                else if (remainder == 0)
                {
                    query.PageIndex = pageCount;
                }
            }

            foreach (var lending in _unitOfWork.Repository<Model.Lending>().Query(filterFunc)
                .Include(l => l.Borrower)
                .Include(l => l.Book.Authors)
                .OrderBy(orderByFunc)
                .SelectPage(query.PageIndex, query.PageSize, out totalSize))
            {
                var uiLending = new Lending();
                lendings.Add(_mapper.Map(lending, uiLending));
            }

            lendingsViewModel.Lendings = new BindingList<Lending>(lendings);

            if (query.PageSize == 1 || remainder == 0)
                lendingsViewModel.PagerData.NumberOfPages = totalSize/query.PageSize;
            else
                lendingsViewModel.PagerData.NumberOfPages = (totalSize/query.PageSize) + 1;

            PopulateOtherPagerInfo(query, lendingsViewModel);

            return lendingsViewModel;
        }

        private Expression<Func<Model.Lending, bool>> GetFilterFunc(GetLendingsPagedSortedQuery query)
        {
            if (string.IsNullOrEmpty(query.Filter))
                return null;

            var filters = new List<Filter>
            {
                new Filter {Operation = Op.Contains, PropertyName = query.FilterBy, Value = query.Filter}
            };

            return ExpressionBuilder.GetExpression<Model.Lending>(filters);
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

        private static void PopulateOtherPagerInfo(GetLendingsPagedSortedQuery query,
            LendingsViewModel lendingsViewModel)
        {
            lendingsViewModel.PagerData.PageNumber = query.PageIndex;
            lendingsViewModel.PagerData.PageSize = query.PageSize;
            lendingsViewModel.PagerData.SortByField = query.SortBy;
            lendingsViewModel.PagerData.SortOrder = query.OrderByDirection;
        }

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
                _mapper.Dispose();
            }

            _disposed = true;
        }
    }
}
