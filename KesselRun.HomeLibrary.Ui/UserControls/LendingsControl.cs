using System;
using System.ComponentModel;
using System.Threading;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.UiLogic;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(LendingsPresenter))]
    public partial class LendingsControl : MvpUserControl, ILendingsView, IStackableView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;
        private readonly Lazy<MainForm> _mainWindow;

        public LendingsControl()
        {
            _mainWindow = new Lazy<MainForm>(() => (MainForm)ParentForm, LazyThreadSafetyMode.None);
            
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            dgvLendings.DataSource = Lendings;
        }

        public event EventHandler ViewClosing;
        public event EventHandler Close;
        public Type NavigationSource { get; set; }
        public BindingList<Lending> Lendings { get; set; }
        public event EventHandler AddLending;

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void LogEventToView(LogEvent logEvent)
        {
            _mainWindow.Value.MainViewModel.MainViewLogItems.Add(logEvent);
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }
        
        public void LoadAddLendingView(Type view)
        {
            _navigator.Navigate(typeof(ILendingsView), view, Parent);            
            
        }

        private void btnAddLending_Click(object sender, System.EventArgs e)
        {
            AddLending(this, System.EventArgs.Empty);
        }

        protected override void OnParentChanged(System.EventArgs e)
        {
            base.OnParentChanged(e);
             var a = Parent;
        }
    }
}
