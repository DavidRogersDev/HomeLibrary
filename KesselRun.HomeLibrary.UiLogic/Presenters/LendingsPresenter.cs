using System;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter: Presenter<ILendingsView>
    {
        public LendingsPresenter(ILendingsView view) : base(view)
        {
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            
        }
    }
}
