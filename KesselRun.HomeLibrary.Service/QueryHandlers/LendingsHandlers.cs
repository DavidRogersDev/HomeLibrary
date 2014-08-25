using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Converters;
using KesselRun.HomeLibrary.Service.Enums;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel;
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
        private readonly ILendingsConverters _keySelectors;

        public LendingsHandlers(IUnitOfWorkAsync unitOfWork, IUniversalMapper mapper, ILendingsConverters keySelectors)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _keySelectors = keySelectors;
        }

        public LendingsViewModel Handle(GetLendingsPagedSortedQuery query)
        {
            var lendingsViewModel = new LendingsViewModel{ PagerData = new PagerData() };
             IList<Lending> lendings = new List<Lending>();
            int totalSize;
            Expression<Func<Model.Lending, bool>> filterFunc = GetFilterFunc(query);

            foreach (var lending in _unitOfWork.Repository<Model.Lending>().Query(filterFunc)
                .Include(l => l.Borrower)
                .Include(l => l.Book.Authors)
                .OrderBy(GetOrderByFunc(query))
                .SelectPage(query.PageIndex, query.PageSize, out totalSize))
             {
                 var uiLending = new Lending();
                 lendings.Add(_mapper.Map(lending, uiLending));
             }

            lendingsViewModel.Lendings = new BindingList<Lending>(lendings);
            lendingsViewModel.PagerData.NumberOfPages = (totalSize / query.PageSize) + 1;
            
            PopulateOtherPagerInfo(query, lendingsViewModel);

            return lendingsViewModel;
        }

        private Expression<Func<Model.Lending, bool>> GetFilterFunc(GetLendingsPagedSortedQuery query)
        {
            if (string.IsNullOrEmpty(query.Filter))
                return null;
            else
            {
                return _keySelectors.FilterToFuncProperty(query.Filter, GetFilterByFromString(query.FilterBy));
            }
        }

        private FilterType GetFilterByFromString(string filterBy)
        {
            switch (filterBy)
            {
                case "LastName": return FilterType.ByLastName;
                default: return FilterType.ByEmail;
            }
        }

        private Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> GetOrderByFunc(
            GetLendingsPagedSortedQuery query)
        {
            switch (query.SortBy)
            {
                case Constants.DateLent:
                case Constants.DueDate:
                case Constants.ReturnDate:
                    return GetOrderByFuncForDates(query);
                case Constants.Borrower:
                case Constants.Email:
                case Constants.Title:
                    return GetOrderByFuncForStrings(query);
            }

            return null;
        }

        private Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> GetOrderByFuncForStrings (
            GetLendingsPagedSortedQuery query)
        {
            switch (query.OrderByDirection)
            {
                case ListSortDirection.Ascending:
                    return l => l.OrderBy(_keySelectors.StringToStringProperty(query.SortBy));
                case ListSortDirection.Descending:
                    return l => l.OrderByDescending(_keySelectors.StringToStringProperty(query.SortBy));
            }

            return null;
        }

        private Func<IQueryable<Model.Lending>, IOrderedQueryable<Model.Lending>> GetOrderByFuncForDates(
            GetLendingsPagedSortedQuery query)
        {
            switch (query.OrderByDirection)
            {
                case ListSortDirection.Ascending:
                    return l => l.OrderBy(_keySelectors.StringToDateTimeProperty(query.SortBy));
                case ListSortDirection.Descending:
                    return l => l.OrderByDescending(_keySelectors.StringToDateTimeProperty(query.SortBy));
            }

            return null;
        }

        private static void PopulateOtherPagerInfo(GetLendingsPagedSortedQuery query, LendingsViewModel lendingsViewModel)
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
            _unitOfWork.Dispose();
        }
    }
}
