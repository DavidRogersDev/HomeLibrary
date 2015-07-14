using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using System;
using System.Threading;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(AddPersonPresenter))]
    public partial class AddPersonControl : MvpUserControl, IAddPersonView
    {
        private readonly Lazy<MainForm> _mainWindow;
        private readonly Navigator _navigator = Navigator.SingleNavigator;

        public AddPersonControl()
        {
            _mainWindow = new Lazy<MainForm>(() => ((MainForm)ParentForm), LazyThreadSafetyMode.None);
            InitializeComponent();
        }

        public event EventHandler ViewClosing;
        public event EventHandler CloseControl;
        
        public void CloseView()
        {
            _navigator.Return(Parent);

        }

        public void LogEventToView(LogEvent logEvent)
        {
            _mainWindow.Value.MainViewModel.MainViewLogItems.Add(logEvent);
        }


        public event EventHandler<AddPersonEventArgs> AddNewPerson;

        private void btnAddPersonButton_Click(object sender, System.EventArgs e)
        {
            var addPersonEventArgs = new AddPersonEventArgs(
                new Person
                {
                    Email = txtEmail.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    IsAuthor = chkIsAuthor.Checked,
                    LastName = txtLastName.Text.Trim(),
                    Sobriquet = txtSobriquet.Text.Trim()
                }
                );

            AddNewPerson(this, addPersonEventArgs);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            CloseControl(this, System.EventArgs.Empty);
        }
    }
}
