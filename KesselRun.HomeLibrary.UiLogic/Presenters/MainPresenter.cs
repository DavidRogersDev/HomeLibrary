using System;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {
        public MainPresenter(IMainView view)
            : base(view)
        {
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.ShowChildView(typeof(ILendingsView));
        }
    }
}
