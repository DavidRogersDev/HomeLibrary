using KesselRun.HomeLibrary.UiLogic.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class PeoplePresenter : Presenter<IPeopleView>, IDisposable 
    {

        public PeoplePresenter(IPeopleView view)
            : base(view)
        {
            View.ViewClosing += View_ViewClosing;
        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        public void Dispose()
        {
            Debug.WriteLine("HIT");
        }
    }
}
