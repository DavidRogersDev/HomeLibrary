using System.Collections.Generic;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.Views;
using System;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class PeoplePresenter : Presenter<IPeopleView>, IDisposable 
    {
        private readonly IQueryProcessor _queryProcessor;
        private bool _disposed;

        public PeoplePresenter(IPeopleView view, IQueryProcessor queryProcessor)
            : base(view)
        {
            _queryProcessor = queryProcessor;
            View.ReloadView += View_ReloadView;
            View.ViewClosing += View_ViewClosing;
        }

        void View_ReloadView(object sender, EventArgs.SearchPeopleEventArgs pagingViewEventArgs)
        {
            IList<Filter> filters = new List<Filter>(pagingViewEventArgs.FilterMetaDataList.Count);

            foreach (var filterMetaData in pagingViewEventArgs.FilterMetaDataList)
            {
                filters.Add(new Filter
                {
                    PropertyName = filterMetaData.FilterBy,
                    Operation = Op.Contains,
                    Value = filterMetaData.FilterValue
                });
            }

            var getPeoplePagedSortedQuery = new GetPeoplePagedSortedQuery
            {
                Filters = filters,
                OrderByDirection = pagingViewEventArgs.SortDirection,
                PageIndex = pagingViewEventArgs.PageIndex,
                PageSize = pagingViewEventArgs.PageSize,
                SortBy = pagingViewEventArgs.SortBy
            };

            LoadPeople(getPeoplePagedSortedQuery);
        }

        private void LoadPeople(GetPeoplePagedSortedQuery getPeoplePagedSortedQuery)
        {
            try
            {
                //Person selectedGridPerson = default(Person);
                var peopleViewModel = _queryProcessor.Process(getPeoplePagedSortedQuery);

                View.PeopleViewModel = peopleViewModel;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                ((IDisposable)_queryProcessor).Dispose();
                _disposed = true;
            }
        }
    }
}
