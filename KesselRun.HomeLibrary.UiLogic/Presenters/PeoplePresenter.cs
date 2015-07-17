using KesselRun.HomeLibrary.UiLogic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMvp;

namespace KesselRun.HomeLibrary.UiLogic.Presenters
{
    public class PeoplePresenter : Presenter<IPeopleView>, IDisposable 
    {

        public PeoplePresenter(IPeopleView view)
            : base(view)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
