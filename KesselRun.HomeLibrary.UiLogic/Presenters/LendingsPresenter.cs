using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter: Presenter<ILendingsView>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IQueryHandler<GetLendingsPagedSortedQuery, IList<Lending>> _handler;

        public LendingsPresenter(ILendingsView view, IQueryProcessor queryProcessor)
            : base(view)
        {
            _queryProcessor = queryProcessor;
            //_handler = handler;
            View.Load += View_Load;
            View.AddLending += View_AddLending;
            _queryProcessor = queryProcessor;
        }

        void View_AddLending(object sender, System.EventArgs e)
        {
            View.LoadAddLendingView(typeof(IAddLendingsView));
        }

        void View_Load(object sender, System.EventArgs e)
        {
            var getLendingsPagedSortedQuery = new GetLendingsPagedSortedQuery{ PageNr = 0, PageSize = 10 };
            var getLendingByPkQuery = new GetLendingByPkQuery{ Id = 1 };


            View.Lendings = new BindingList<Lending>(_queryProcessor.Process(getLendingsPagedSortedQuery));
            //var lending = _queryProcessor.Process(getLendingByPkQuery);
            //var peeps = new List<Person>(_queryProcessor.Process(getPeoplePagedSortedQuery));
        }
    }
}
