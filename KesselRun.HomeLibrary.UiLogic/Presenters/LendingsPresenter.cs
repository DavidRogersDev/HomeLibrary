using System;
using System.ComponentModel;
using KesselRun.HomeLibrary.Common.Extensions;
using KesselRun.HomeLibrary.Service;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel.Models;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class LendingsPresenter: Presenter<ILendingsView>
    {
        private readonly ILendingsService _lendingsService;

        public LendingsPresenter(ILendingsView view, ILendingsService lendingsService)
            : base(view)
        {
            _lendingsService = lendingsService;
            View.Load += View_Load;
        }

        void View_Load(object sender, EventArgs e)
        {
            View.Lendings = new BindingList<Lending>(_lendingsService.GetLendings());
        }
    }
}
