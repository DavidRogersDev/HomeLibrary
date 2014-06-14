using System;
using System.ComponentModel;
using FluentValidation;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class AddLendingsPresenter : Presenter<IAddLendingsView>, IDisposable
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public AddLendingsPresenter(IAddLendingsView view, ICommandProcessor commandProcessor, IQueryProcessor queryProcessor) : base(view)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            View.ViewClosing += View_ViewClosing;
            View.CloseControl += ViewCloseControl;
            View.Load += View_Load;
            View.AddNewLending += View_AddNewLending;
        }

        void View_Load(object sender, System.EventArgs e)
        {
            var getPeopleSortedQuery = new GetPeopleSortedQuery {SortBy = "id"};
            var getBooksSorted = new GetBooksSorted {SortBy = "id"};

            var addLendingViewModel = new AddLendingViewModel
            {
                Books = new BindingList<Book>(_queryProcessor.Process(getBooksSorted)),
                People = new BindingList<Person>(_queryProcessor.Process(getPeopleSortedQuery))
            };

            View.AddLendingViewModel = addLendingViewModel;
        }

        void View_AddNewLending(object sender, EventArgs.AddLendingEventArgs e)
        {
            View.LogEventToView(new LogEvent{ Event = "Adding new Lending"});

            var addLendingCommand = new AddLendingCommand
            {
                BookId = e.BookId,
                BorrowerId = e.BorrowerId,
                DateLent = e.DateLent,
                DateDue = e.DateDue
            };

            try
            {
                _commandProcessor.Execute(addLendingCommand);

                View.LogEventToView(new LogEvent { Event = "Lending added successfully" });
            }
            catch (ValidationException validationException)
            {
                View.LogEventToView(new LogEvent { Event = validationException.Message }); //TODO: log informative message. MessageBox or lable show as well.
            }

        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            //PresenterBinder.Factory.Release(this);
        }

        void ViewCloseControl(object sender, System.EventArgs e)
        {
            View.CloseView();
            PresenterBinder.Factory.Release(this);
        }

        public void Dispose()
        {
            //  to implement
            //  TODO: Dispose of all UOW in various entities
        }
    }
}
