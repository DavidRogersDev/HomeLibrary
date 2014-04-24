using System;
using System.Collections.Generic;
using System.ComponentModel;
using KesselRun.HomeLibrary.Service;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
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
    }
}
