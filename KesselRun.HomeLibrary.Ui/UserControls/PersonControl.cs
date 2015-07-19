using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMvp.Forms;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(PeoplePresenter))]
    public partial class PersonControl : MvpUserControl, IPeopleView
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
    }
}
