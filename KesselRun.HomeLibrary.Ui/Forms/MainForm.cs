using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.UserControls;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Services;
using KesselRun.HomeLibrary.UiLogic.Views;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.Forms
{
    [PresenterBinding(typeof(MainPresenter))]
    public partial class MainForm : MvpForm, IMainView, IWindow
    {
        private Utilities _utilities = new Utilities(new Dictionary<Type, Type>());
        private ViewMapper _viewMapper = new ViewMapper();

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public event EventHandler ViewClosing;
        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void ReleasePresenter(IPresenter presenter)
        {
            throw new NotImplementedException();
        }

        public void ShowChildView(Type view)
        {
            try
            {
                var typeOfControl = _viewMapper.Bla(view);
                var ctors = typeOfControl.GetConstructors();
                var obj = ctors[0].Invoke(new object[] {});
                this.MainContentPanel.Controls.Add((MvpUserControl) obj);
            }
            catch (Exception exception)
            {
                
            }
        }
        
    }

    public class ViewMapper
    {
        private const string Lendingscontrol = "KesselRun.HomeLibrary.Ui.UserControls.LendingsControl";

        public Type Bla(Type type) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var t in assembly.GetExportedTypes())
            {
                if (type.IsAssignableFrom(t))
                    return t;
            }

            var lendingsControl = assembly.CreateInstance(Lendingscontrol, false, BindingFlags.ExactBinding, null, null, null, null) as LendingsControl;

            return null;
        }
    }
}
