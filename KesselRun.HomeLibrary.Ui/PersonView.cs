using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.UiLogic.Events;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiLogic.Views.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui
{
    [PresenterBinding(typeof(PeoplePresenter))]
    public partial class PersonView : MvpForm, IPersonView
    {
        public PersonView()
        {
            InitializeComponent();
        }

        public event EventHandler ViewClosing;
        public event EventHandler EditPersonClicked;
        public event EventHandler<PagingEventArgs> NextPageSubmitted;
        public event EventHandler<PagingAndSortingEventArgs> SortColumn;
        public PersonViewModel ViewModel { get; set; }
        
        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ViewClosing(this, EventArgs.Empty);
            base.OnClosing(e);
        }
    }
}
