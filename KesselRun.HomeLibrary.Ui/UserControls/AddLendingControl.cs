using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(AddLendingsPresenter))]
    public partial class AddLendingControl : MvpUserControl, IAddLendingsView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;

        public AddLendingControl()
        {
            InitializeComponent();
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public event EventHandler ViewClosing;
        public event EventHandler Close;
        public string ControlStack { get; set; }

        public void CloseView()
        {
            _navigator.Return(Parent);
            ViewClosing(this, EventArgs.Empty);
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(this, EventArgs.Empty);
        }
    }
}
