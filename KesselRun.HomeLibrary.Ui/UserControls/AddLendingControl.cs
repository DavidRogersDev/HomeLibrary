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

        public AddLendingControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            cboBook.DataSource = AddLendingViewModel.Books;
            cboBorrower.DataSource = AddLendingViewModel.People;
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public event EventHandler ViewClosing;
        public event EventHandler Close;
        public string ControlStack { get; set; }

        public void CloseView()
        {
            _navigator.Return(Parent);
            ViewClosing(this, System.EventArgs.Empty);
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close(this, System.EventArgs.Empty);
        }

        public event EventHandler<AddLendingEventArgs> AddNewLending;
        public AddLendingViewModel AddLendingViewModel { get; set; }

        public void AddLending(int bookId, int borrowerId, DateTime dateLent, DateTime? dateDue)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddNewLending(this, new AddLendingEventArgs((int)cboBook.SelectedValue, (int)cboBorrower.SelectedValue, dtpDateLent.Value, dtpDateDue.Value));
        }
    }
}
