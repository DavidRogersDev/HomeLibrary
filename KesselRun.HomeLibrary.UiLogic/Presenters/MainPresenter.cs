using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class MainPresenter : Presenter<IMainView>
    {
        private readonly INavigationService _navigationService;


        public MainPresenter(IMainView view)
            : base(view)
        {
            //_navigationService = navigationService;
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            //_navigationService.NavigateToView(typeof(ILendingsView));
            View.ShowChildView(typeof(ILendingsView));

        }
    }
}
