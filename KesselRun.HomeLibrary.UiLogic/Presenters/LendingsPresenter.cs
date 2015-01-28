using System;
using System.Diagnostics;
using System.Linq;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;
using WinFormsMvp.Binder;
using SCMDA = System.ComponentModel.DataAnnotations;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter : Presenter<ILendingsView>, IDisposable
    {
        private readonly IQueryProcessor _queryProcessor;

        public LendingsPresenter(ILendingsView view, IQueryProcessor queryProcessor)
            : base(view)
        {
            _queryProcessor = queryProcessor;
            View.ViewClosing += View_ViewClosing;
            View.AddLending += View_AddLending;
            View.ReloadView += View_ReloadView;
            _queryProcessor = queryProcessor;
        }

        private void View_ReloadView(object sender, SearchLendingsEventArgs lendingsViewEventArgs)
        {
            AddLendingCommand command;

            var getLendingsPagedSortedQuery = new GetLendingsPagedSortedQuery
            {
                Filter = lendingsViewEventArgs.Filter,
                FilterBy = lendingsViewEventArgs.FilterBy,
                FilterOperation = lendingsViewEventArgs.FilterOperator,
                OrderByDirection = lendingsViewEventArgs.SortDirection,
                PageIndex = lendingsViewEventArgs.PageIndex,
                PageSize = lendingsViewEventArgs.PageSize,
                SortBy = lendingsViewEventArgs.SortBy,
                SelectedLendingId = lendingsViewEventArgs.SelectedLendingId
            };
            LoadLendings(getLendingsPagedSortedQuery);
        }

        private void ActionMethod(Service.Commands.AddLendingCommand bla)
        {
            Trace.WriteLine(bla.DateDue.Value.ToString());
        }

        private void View_ViewClosing(object sender, System.EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        private void View_AddLending(object sender, System.EventArgs e)
        {
            View.LoadAddLendingView(typeof (IAddLendingsView));
        }

        private void LoadLendings(GetLendingsPagedSortedQuery getLendingsPagedSortedQuery)
        {
            try
            {
                Lending selectedGridLending = default(Lending);

                //var selectedLendingId = getLendingsPagedSortedQuery.SelectedLendingId;

                var lendingsViewModel = _queryProcessor.Process(getLendingsPagedSortedQuery);

                //if (selectedLendingId > -1)
                //    selectedGridLending = lendingsViewModel.Lendings.SingleOrDefault(gridLending => gridLending.Id == selectedLendingId);

                //if (!ReferenceEquals(selectedGridLending, null))
                //    lendingsViewModel.SelectedGridLendingId = selectedGridLending.Id;

                //if (lendingsViewModel.PagerData.PageNumber > lendingsViewModel.PagerData.NumberOfPages)
                //    lendingsViewModel.PagerData.PageNumber = lendingsViewModel.PagerData.NumberOfPages;

                View.LendingsViewModel = lendingsViewModel;
            }
            catch (SCMDA.ValidationException validationException)
            {
                View.LogEventToView(new LogEvent {Event = validationException.Message}); //TODO: log informative message
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
