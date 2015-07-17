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

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(PeoplePresenter))]
    public partial class PersonControl : MvpUserControl, IPeopleView
    {
        public PersonControl()
        {
            InitializeComponent();
        }

        public event EventHandler ViewClosing;

        public event EventHandler CloseControl;

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void LogEventToView(UiModel.LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
