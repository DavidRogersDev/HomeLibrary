using System;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.UiLogic;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;
using WinFormsMvp.Messaging;

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

            logDisplayBindingSource.DataSource = MainViewModel;
            logDisplayBindingSource.DataMember = "MainViewLogItems";
            lstMainViewLog.DataSource = logDisplayBindingSource;
        }

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        public event EventHandler ViewClosing;
        public event EventHandler CloseControl;
        public event EventHandler NavigateToPeopleView;
        public string ControlStack { get; set; }
        public MainViewModel MainViewModel { get; set; }
        public LendingsViewModel LendingsViewModel { get; set; }

        public void CloseView()
        {
            _navigator.ClearNavigationBase(MainContentPanel);
            ViewClosing(this, System.EventArgs.Empty);
            OnFormClosing(new System.Windows.Forms.FormClosingEventArgs(System.Windows.Forms.CloseReason.UserClosing, false));
            //Close();
        }

        public void LogEventToView(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }   

        public void ShowChildView(Type view)
        {
            try
            {
                _navigator.ClearNavigationBase(MainContentPanel);
                //_navigator.ClearContainer(MainContentPanel);
                _navigator.NavigateTo(view,  MainContentPanel);
            }
            catch (Exception exception)
            {
                
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            CloseControl(this, System.EventArgs.Empty);
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void btnBooks_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnPeople_Click(object sender, System.EventArgs e)
        {
            NavigateToPeopleView(this, System.EventArgs.Empty);
        }

    }
}
