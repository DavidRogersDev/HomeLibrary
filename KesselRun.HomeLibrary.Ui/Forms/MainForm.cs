using System;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;
using NavigationService = KesselRun.HomeLibrary.Ui.Core.NavigationService;

namespace KesselRun.HomeLibrary.Ui.Forms
{
    [PresenterBinding(typeof(MainPresenter))]
    public partial class MainForm : MvpForm, IMainView
    {
        private readonly NavigationService _navigationService = NavigationService.SingleNavigationService;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _navigationService.NavigationRootControl = this;
            base.OnLoad(e);
        }

        public event EventHandler ViewClosing;
        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            PresenterBinder.Factory.Release(presenter);
        }

        public void ShowChildView(Type view)
        {
            try
            {
                _navigationService.NavigateTo(view, MainContentPanel);
            }
            catch (Exception exception)
            {
                
            }
        }
        
    }
}
