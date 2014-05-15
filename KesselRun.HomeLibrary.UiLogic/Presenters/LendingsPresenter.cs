using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;
using WinFormsMvp.Binder;
using SCMDA = System.ComponentModel.DataAnnotations;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter: Presenter<ILendingsView>, IDisposable
    {
        private readonly IQueryProcessor _queryProcessor;

        public LendingsPresenter(ILendingsView view, IQueryProcessor queryProcessor)
            : base(view)
        {
            _queryProcessor = queryProcessor;
            View.Load += View_Load;
            View.ViewClosing += View_ViewClosing;
            View.AddLending += View_AddLending;
            View.ReloadView += View_ReloadView;
            _queryProcessor = queryProcessor;
        }

        void View_ReloadView(object sender, LendingsViewEventArgs lendingsViewEventArgs)
        {
            var getLendingsPagedSortedQuery = new GetLendingsPagedSortedQuery { PageNr = lendingsViewEventArgs.PageIndex, PageSize = lendingsViewEventArgs.PageSize };
            LoadLendings(getLendingsPagedSortedQuery);
        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        void View_AddLending(object sender, System.EventArgs e)
        {
            View.LoadAddLendingView(typeof(IAddLendingsView));
        }

        void View_Load(object sender, System.EventArgs e)
        {
        }

        private void LoadLendings(GetLendingsPagedSortedQuery getLendingsPagedSortedQuery)
        {
            try
            {
                var lendings = _queryProcessor.Process(getLendingsPagedSortedQuery);
                View.Lendings = new BindingList<Lending>(lendings);
            }
            catch (SCMDA.ValidationException validationException)
            {
                View.LogEventToView(new LogEvent{ Event = validationException.Message});   //TODO: log informative message
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
