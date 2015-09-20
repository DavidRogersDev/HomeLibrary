using KesselRun.HomeLibrary.UiLogic.Views;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class PeoplePresenter : Presenter<IPeopleView>, IDisposable 
    {
        private bool _disposed;

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                //((IDisposable)_queryProcessor).Dispose();
                _disposed = true;
            }
        }
    }
}
