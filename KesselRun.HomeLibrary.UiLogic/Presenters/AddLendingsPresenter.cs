using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class AddLendingsPresenter : Presenter<IAddLendingsView>, IDisposable
    {
        public AddLendingsPresenter(IAddLendingsView view) : base(view)
        {
            View.ViewClosing += View_ViewClosing;
            View.Close += view_Close;
        }

        void View_ViewClosing(object sender, EventArgs e)
        {
            View.ReleasePresenter(this);
        }

        void view_Close(object sender, EventArgs e)
        {
            View.CloseView();
        }

        public void Dispose()
        {
            //  to implement
        }
    }
}
