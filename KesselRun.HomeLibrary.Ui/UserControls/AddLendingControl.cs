using System;
using System.Threading;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.UiLogic;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(AddLendingsPresenter))]
    public partial class AddLendingControl : MvpUserControl, IAddLendingsView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;
        private readonly Lazy<MainForm> _mainWindow;

        public AddLendingControl()
        {
            _mainWindow = new Lazy<MainForm>(() => ((MainForm)ParentForm), LazyThreadSafetyMode.None);
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            ThrowExceptionIfNoPresenterBound = true;
            cboBook.DataSource = AddLendingViewModel.Books;
            cboBorrower.DataSource = AddLendingViewModel.People;
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public event EventHandler ViewClosing;
        public event EventHandler Close;
        public string ControlStack { get; set; }
        public event EventHandler<AddLendingEventArgs> AddNewLending;
        public AddLendingViewModel AddLendingViewModel { get; set; }

        public void CloseView()
        {
            _navigator.Return(Parent);
            ViewClosing(this, System.EventArgs.Empty);
        }

        public void LogEventToView(LogEvent logEvent)
        {
            _mainWindow.Value.MainViewModel.MainViewLogItems.Add(logEvent);
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close(this, System.EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddNewLending(this, new AddLendingEventArgs((int)cboBook.SelectedValue, (int)cboBorrower.SelectedValue, dtpDateLent.Value, dtpDateDue.Value));
        }
    }
}
