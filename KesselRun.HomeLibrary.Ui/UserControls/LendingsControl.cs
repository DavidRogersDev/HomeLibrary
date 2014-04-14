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
        public LendingsControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dgvLendings.DataSource = Lendings;
        }

        public event EventHandler ViewClosing;
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
    }
}
