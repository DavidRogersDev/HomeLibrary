using FluentValidation;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class AddPersonPresenter : Presenter<IAddPersonView>, IDisposable
    {
        private readonly ICommandProcessor _commandProcessor;

        public AddPersonPresenter(IAddPersonView view, ICommandProcessor commandProcessor) : base(view)
        {
            _commandProcessor = commandProcessor;
            View.AddNewPerson += View_AddNewPerson;
            View.CloseControl += View_CloseControl;
        }

        void View_CloseControl(object sender, System.EventArgs e)
        {
            View.CloseView();
            PresenterBinder.Factory.Release(this);
        }

        void View_AddNewPerson(object sender, EventArgs.AddPersonEventArgs e)
        {
            View.LogEventToView(new LogEvent { Event = "Adding new Person" });

            var addPersonCommand = new AddPersonCommand
            {
                Email = e.Person.Email,
                FirstName = e.Person.FirstName,
                LastName = e.Person.LastName,
                IsAuthor = e.Person.IsAuthor,
                Sobriquet = e.Person.Sobriquet
            };

            try
            {
                _commandProcessor.Execute(addPersonCommand);

                View.LogEventToView(new LogEvent { Event = "Person added successfully" });
            }
            catch (ValidationException validationException)
            {
                View.LogEventToView(new LogEvent { Event = validationException.Message }); //TODO: log informative message. MessageBox or lable show as well.
            }

        }

        public void Dispose()
        {
            //  to implement
            ((IDisposable)_commandProcessor).Dispose();
        }
    }
}
