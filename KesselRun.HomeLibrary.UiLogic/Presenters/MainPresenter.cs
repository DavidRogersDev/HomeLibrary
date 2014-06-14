using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class MainPresenter : Presenter<IMainView>, IDisposable
    {
        public MainPresenter(IMainView view)
            : base(view)
        {
            View.Load += View_Load;
            View.ViewClosing += View_ViewClosing;
            View.CloseControl += ViewCloseControl;
        }

        void ViewCloseControl(object sender, System.EventArgs e)
        {
            View.CloseView();
        }

        void View_ViewClosing(object sender, System.EventArgs e)
        {
            PresenterBinder.Factory.Release(this);
        }

        void View_Load(object sender, System.EventArgs e)
        {
            //try
            //{
            //    var lendings = _lendingsService.GetLendings();
            //}
            //catch (Exception ex)
            //{
            //}
            View.MainViewModel = new MainViewModel { MainViewLogItems = new BindingList<LogEvent>(new List<LogEvent> { new LogEvent { Event = "App loaded" } }) };
            View.ShowChildView(typeof(ILendingsView));
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
