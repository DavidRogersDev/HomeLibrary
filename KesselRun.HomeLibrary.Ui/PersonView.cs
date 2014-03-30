using System;
using System.ComponentModel;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Assets.Resources;
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

        private void PersonView_Load(object sender, EventArgs e)
        {
            dgvPersons.AllowUserToAddRows = false;



            dgvcDelete.Image = ImageResources.delete;
            dgvcEdit.Image = ImageResources.edit;

            dgvPersons.DataSource = ViewModel.People;
        }

        public event EventHandler ViewClosing;
        public event EventHandler EditPersonClicked;
        public PersonViewModel ViewModel { get; set; }

        private void dgvPersons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgvPersons.Columns[e.ColumnIndex].Name)
            {
                case "dgvcIsAuthor":
                    bool isAuthor;

                    if (bool.TryParse(dgvPersons.Rows[e.RowIndex].Cells["dgvcIsAuthor"].Value.ToString(),
                        out isAuthor))
                    {
                        e.Value = isAuthor ? ImageResources.tick : ImageResources.cross;
                    }
                    break;
            }
        }
        
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
