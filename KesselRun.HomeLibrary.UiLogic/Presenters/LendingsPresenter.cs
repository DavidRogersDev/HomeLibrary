using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Common.Extensions;
using KesselRun.HomeLibrary.Service;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Infrastructure.Queries;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter: Presenter<ILendingsView>
    {
        private readonly ILendingsService _lendingsService;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IQueryHandler<GetLendingsPagedSortedQuery, IList<Lending>> _handler;

        public LendingsPresenter(ILendingsView view, ILendingsService lendingsService, IQueryProcessor queryProcessor)
            : base(view)
        {
            _lendingsService = lendingsService;
            _queryProcessor = queryProcessor;
            //_handler = handler;
            View.Load += View_Load;
            _queryProcessor = queryProcessor;
        }

        void View_Load(object sender, EventArgs e)
        {
            var getLendingsPagedSortedQuery = new GetLendingsPagedSortedQuery{ PageNr = 0, PageSize = 10 };
            var getPeoplePagedSortedQuery = new GetPeoplePagedSortedQuery { PageNr = 0, PageSize = 10 };

            View.Lendings = new BindingList<Lending>(_queryProcessor.Process(getLendingsPagedSortedQuery));

            var peeps = new List<Person>(_queryProcessor.Process(getPeoplePagedSortedQuery));
        }
    }
}
