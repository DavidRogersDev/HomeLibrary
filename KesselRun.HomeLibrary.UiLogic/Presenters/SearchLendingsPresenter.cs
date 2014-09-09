using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class SearchLendingsPresenter : Presenter<ISearchLendingsView>, IDisposable
    {
        private bool _disposed;

        public SearchLendingsPresenter(ISearchLendingsView view) : base(view)
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
