using System;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.Forms
{
    [PresenterBinding(typeof(MainPresenter))]
    public partial class MainForm : MvpForm, IMainView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            _navigator.NavigationRootControl = this;
            base.OnLoad(e);
        }

        public event EventHandler ViewClosing;
        public event EventHandler Close;
        public string ControlStack { get; set; }

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
                _navigator.NavigateTo(view,  MainContentPanel);
            }
            catch (Exception exception)
            {
                
            }
        }
        
    }
}
