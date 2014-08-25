using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Assets.Resources;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp;
using WinFormsMvp.Forms;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(LendingsPresenter))]
    public partial class LendingsControl : MvpUserControl, ILendingsView
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;
        private readonly Lazy<MainForm> _mainWindow;

        public LendingsControl()
        {
            _mainWindow = new Lazy<MainForm>(() => (MainForm)ParentForm, LazyThreadSafetyMode.None);
            
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
        }

        public event EventHandler ViewClosing;
        public event EventHandler CloseControl;
        public Type NavigationSource { get; set; }
        public LendingsViewModel LendingsViewModel { get; set; }
        public event EventHandler AddLending;
        public event EventHandler<LendingsViewEventArgs> ReloadView;

        public void CloseView()
        {
            ViewClosing(this, System.EventArgs.Empty);
        }

        public void LogEventToView(LogEvent logEvent)
        {
            _mainWindow.Value.MainViewModel.MainViewLogItems.Add(logEvent);
        }
        
        public void LoadAddLendingView(Type view)
        {
            _navigator.Navigate(typeof(ILendingsView), view, Parent);
        }

        private void DgvLendingsCellFormatting(object sender, DataGridViewCellFormattingEventArgs dataGridViewCellFormattingEventArgs)
        {
            int rowIndex = dataGridViewCellFormattingEventArgs.RowIndex;
            int columnIndex = dataGridViewCellFormattingEventArgs.ColumnIndex;

            dgvLendings.Rows[rowIndex].Cells[columnIndex].ToolTipText = "Return Book";

            switch (dgvLendings.Columns[columnIndex].Name)
            {
                case "dgvicReturn":
                    bool isAuthor;

                    //if (bool.TryParse(dgvLendings.Rows[dataGridViewCellFormattingEventArgs.RowIndex].Cells["dgvicReturn"].Value.ToString(),
                    //    out isAuthor))
                    {
                        dataGridViewCellFormattingEventArgs.Value = ImageResources.Return;
                    }
                    //else
                    {
                        //todo: bad
                    }
                    break;
            }            
        }

        private void btnAddLending_Click(object sender, System.EventArgs e)
        {
            AddLending(this, System.EventArgs.Empty);
        }

        protected override void OnParentChanged(System.EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent != null)
            {
                ReloadView(this, new LendingsViewEventArgs(dgvPager.PageSize, dgvPager.PageIndex, dgvPager.SortByColumn, dgvPager.SortOrder));
                dgvLendings.DataSource = LendingsViewModel.Lendings;
                dgvPager.PageCount = LendingsViewModel.PagerData.NumberOfPages;
                dgvPager.PageIndex = LendingsViewModel.PagerData.PageNumber;
                dgvPager.PageSize = LendingsViewModel.PagerData.PageSize;
                dgvPager.SortOrder = LendingsViewModel.PagerData.SortOrder;

                dgvPager.AdjustPreviousNextButtons("StartUp");
            }
        }


        private void dgvPager_PageChanged(object sender, PagedEventArgs e)
        {
            ReloadView(this, new LendingsViewEventArgs(dgvPager.PageSize, e.NewPageIndex, dgvPager.SortByColumn, dgvPager.SortOrder));
            dgvLendings.DataSource = LendingsViewModel.Lendings;

            dgvPager.PageCount = LendingsViewModel.PagerData.NumberOfPages;
            dgvPager.PageIndex = LendingsViewModel.PagerData.PageNumber;
            dgvPager.PageSize = LendingsViewModel.PagerData.PageSize;
            dgvPager.SortOrder = LendingsViewModel.PagerData.SortOrder;

            dgvPager.AdjustPreviousNextButtons(e.EventRaised);
        }

        private void dgvLendings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            var columnClicked = dgvLendings.Columns[e.ColumnIndex];

            //  if less than 0, must be the Header column.
            if (rowIndex < 0 && columnClicked.SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                SortOutSorting(columnClicked);

                ReloadView(this, new LendingsViewEventArgs(dgvPager.PageSize, dgvPager.PageIndex, dgvPager.SortByColumn, dgvPager.SortOrder));
                dgvLendings.DataSource = LendingsViewModel.Lendings;

                dgvPager.PageCount = LendingsViewModel.PagerData.NumberOfPages;
                dgvPager.PageIndex = LendingsViewModel.PagerData.PageNumber;
                dgvPager.PageSize = LendingsViewModel.PagerData.PageSize;
                dgvPager.SortOrder = LendingsViewModel.PagerData.SortOrder;
            }
        }

        private void SortOutSorting(DataGridViewColumn columnClicked)
        {
            if (dgvPager.SortByColumn == columnClicked.DataPropertyName)
            {
                dgvPager.SortOrder = dgvPager.SortOrder == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                dgvPager.SortByColumn = columnClicked.DataPropertyName;
                dgvPager.SortOrder = ListSortDirection.Ascending;
            }
        }

    }
}
