using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class MainPresenter : Presenter<IMainView>, IDisposable
    {
        private bool _disposed;

        public MainPresenter(IMainView view)
            : base(view)
        {
            View.Load += View_Load;
            View.ViewClosing += View_ViewClosing;
            View.CloseControl += ViewCloseControl;
            View.NavigateToLendingsView += View_NavigateToLendingsView;
            View.NavigateToPeopleView += View_NavigateToPeopleView;
        }

        void View_NavigateToLendingsView(object sender, System.EventArgs e)
        {
            View.ShowChildView(typeof(ILendingsView));
        }

        void View_NavigateToPeopleView(object sender, System.EventArgs e)
        {
            View.ShowChildView(typeof(IPeopleView));
        }

        //void View_SearchLendings(object sender, EventArgs.SearchPagingEventArgs e)
        //{
        //    var query = new GetLendingsPagedSortedQuery
        //    {
        //        Filter = e.Filter,
        //        FilterBy = e.FilterBy,
        //        OrderByDirection = ListSortDirection.Ascending,
        //        PageIndex = 1,
        //        PageSize = 10,
        //        SortBy = "Borrower"
        //    };

        //    View.LendingsViewModel = _queryProcessor.Process(query);
        //}

        void ViewCloseControl(object sender, System.EventArgs e)
        {
            View.CloseView();
            PresenterBinder.Factory.Release(this);
        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            //PresenterBinder.Factory.Release(this);
        }

        void View_Load(object sender, System.EventArgs e)
        {
            //try
            //{
            //    var lendings = _lendingsService.GetLendings();
            //}
            //catch (Exception ex)
            //{
            //}
            View.MainViewModel = new MainViewModel { MainViewLogItems = new BindingList<LogEvent>(new List<LogEvent> { new LogEvent { Event = "App loaded" } }) };
            View.ShowChildView(typeof(ILendingsView));
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
                _disposed = true;
            }
        }
    }
}
