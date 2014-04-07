using System;
using KesselRun.HomeLibrary.Service;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {
        private readonly ILendingsService _lendingsService;

        public MainPresenter(IMainView view, ILendingsService lendingsService)
            : base(view)
        {
            _lendingsService = lendingsService;
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            try
            {
                var lendings = _lendingsService.GetLendings();
            }
            catch (Exception ex)
            {
            }

            View.ShowChildView(typeof(ILendingsView));
        }
    }
}
