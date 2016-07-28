using System.ComponentModel;
using System.Linq.Expressions;
using AutoMapper;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class PeopleQueryHandlers :
        IQueryHandler<GetPeopleSortedQuery, IList<Person>>,
        IQueryHandler<GetPeoplePagedSortedQuery, PeopleViewModel>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;
        private bool _disposed = false;

        public PeopleQueryHandlers(IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderByFunc<T>(GetPeoplePagedSortedQuery query)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");

            var memberExpression = ExpressionBuilder.GetMember(param, query.SortBy);

            return ExpressionBuilder.GetExpressionSortFunc<T>(param, memberExpression, query.OrderByDirection);
        }
        
        private Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderByFunc<T>(GetPeopleSortedQuery query)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");

            var memberExpression = ExpressionBuilder.GetMember(param, query.SortBy);

            return ExpressionBuilder.GetExpressionSortFunc<T>(param, memberExpression, query.OrderByDirection);
        }

        public IList<Person> Handle(GetPeopleSortedQuery query)
        {
            IList<Person> people = new List<Person>();
            query.OrderByDirection = ListSortDirection.Descending;
            var orderByFunc = GetOrderByFunc<Model.Person>(query);

            foreach (var person in _unitOfWork.Repository<Model.Person>().Query().OrderBy(orderByFunc).Select())
            {
                var uiPerson = new Person();
                people.Add(_mapper.Map(person, uiPerson));
            }

            return people;
        }

        public PeopleViewModel Handle(GetPeoplePagedSortedQuery query)
        {
            var peopleViewModel = new PeopleViewModel { PagerData = new PagerData() };
            IList<Person> people = new List<Person>();
            Expression<Func<Model.Person, bool>> filterFunc = GetFilterFunc(query);
            Func<IQueryable<Model.Person>, IOrderedQueryable<Model.Person>> orderByFunc = GetOrderByFunc<Model.Person>(query);
            var personRepository = _unitOfWork.Repository<Model.Person>();

            int totalSize = personRepository.Query().Select().Count();

            PagerHelper.ProcessPagingData(query, peopleViewModel.PagerData, totalSize);

            foreach (var person in _unitOfWork.Repository<Model.Person>().Query(filterFunc)
                //.Include(l => l.Books)
                //.Include(p => p.Lendings.Select(l => l.Book.Authors))
                .OrderBy(orderByFunc)
                .SelectPage(query.PageIndex, query.PageSize, out totalSize))
            {
                var uiPerson = new Person();
                people.Add(_mapper.Map(person, uiPerson));
            }

            peopleViewModel.People = new BindingList<Person>(people);

            return peopleViewModel;
            
        }

        private Expression<Func<Model.Person, bool>> GetFilterFunc(GetPeoplePagedSortedQuery query)
        {
            if (!query.Filters.Any())
                return null;

            return ExpressionBuilder.GetExpression<Model.Person>(query.Filters);
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
