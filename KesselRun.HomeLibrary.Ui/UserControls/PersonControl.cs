using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using System;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(PeoplePresenter))]
    public partial class PersonControl : MvpUserControl, IPeopleView, IHydrateOnFocus
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;
        private readonly Lazy<MainForm> _mainWindow;

        public PersonControl()
        {
            InitializeComponent();
        }

        public event EventHandler ViewClosing;

        public event EventHandler CloseControl;

        public void CloseView()
        {
            ViewClosing(this, System.EventArgs.Empty);
        }

        public void LogEventToView(UiModel.LogEvent logEvent)
        {
            _mainWindow.Value.MainViewModel.MainViewLogItems.Add(logEvent);
        }

        public void HydrateWithDataOnFocus()
        {
            // TODO: Implement duh.
        }
    }
}
