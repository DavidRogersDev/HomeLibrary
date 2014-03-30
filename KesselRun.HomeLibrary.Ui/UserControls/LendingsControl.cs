using System;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    public partial class LendingsControl : MvpUserControl, ILendingsView
    {
        public LendingsControl()
        {
            InitializeComponent();
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
    }
}
