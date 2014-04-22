using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(LendingsPresenter))]
    public partial class LendingsControl : MvpUserControl, ILendingsView, IStackableView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;

        public LendingsControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            dgvLendings.DataSource = Lendings;
        }

        public event EventHandler ViewClosing;
        public event EventHandler Close;

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            throw new NotImplementedException();
        }

        public Type NavigationSource { get; set; }
        public BindingList<Lending> Lendings { get; set; }
        public event EventHandler AddLending;
        
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
