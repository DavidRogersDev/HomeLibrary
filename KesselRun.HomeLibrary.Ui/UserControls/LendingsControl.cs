using KesselRun.HomeLibrary.Ui.Assets.Resources;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Core.Config;
using KesselRun.HomeLibrary.Ui.CustomControls;
using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;
using KesselRun.HomeLibrary.Ui.Forms;
using KesselRun.HomeLibrary.Ui.Messaging;
using KesselRun.HomeLibrary.UiLogic.EventArgs;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.Models;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;
using WinFormsMvp.Messaging;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
	[PresenterBinding(typeof (LendingsPresenter))]
	public partial class LendingsControl : MvpUserControl, ILendingsView, IHydrateOnFocus
	{
		private readonly Navigator _navigator = Navigator.SingleNavigator;
		private readonly Lazy<MainForm> _mainWindow;
		private int NoSelectedItem = -1;

		public LendingsControl()
		{
			_mainWindow = new Lazy<MainForm>(() => (MainForm) ParentForm, LazyThreadSafetyMode.None);

			InitializeComponent();
		}

		#region ILendingsView

		public event EventHandler AddPerson;
		public event EventHandler AddLending;
		public event EventHandler ViewClosing;
		public event EventHandler CloseControl;
		public LendingsViewModel LendingsViewModel { get; set; }
		public event EventHandler<SearchLendingsEventArgs> ReloadView;
		public event EventHandler<SearchLendingsEventArgs> SearchLendings;

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
			_navigator.Navigate(view, Parent);
		}

		public void LoadAddPersonView(Type view)
		{
			_navigator.Navigate(view, Parent);
		}

		#endregion

 
		private static SearchLendingsViewModel GetSearchParameters(int selectedGridLendingId)
		{
			var searchLendingsViewModel = new SearchLendingsViewModel
			{
				SelectedGridLendingId = selectedGridLendingId
			};

			PresenterBinder.MessageBus.Send(
				new GenericMessage<SearchLendingsViewModel>(searchLendingsViewModel),
				MessageIds.GetFilterParametersRequest
				);

			return searchLendingsViewModel;
		}

		private void ReSyncGridAndPager()
		{
			dgvLendings.DataSource = LendingsViewModel.Lendings;

			dgvPager.PageCount = LendingsViewModel.PagerData.NumberOfPages;
			dgvPager.PageIndex = LendingsViewModel.PagerData.PageNumber;
			dgvPager.PageSize = LendingsViewModel.PagerData.PageSize;
			dgvPager.SortOrder = LendingsViewModel.PagerData.SortOrder;
		}

		private void SortOutSorting(DataGridViewColumn columnClicked)
		{
		    
            if(dgvLendings.Tag == columnClicked.DataPropertyName)
			//if (dgvPager.SortByColumn == columnClicked.DataPropertyName)
			{
				dgvPager.SortOrder = dgvPager.SortOrder == ListSortDirection.Ascending
					? ListSortDirection.Descending
					: ListSortDirection.Ascending;
			}
			else
			{
				dgvPager.SortByColumn = GetSortByParameter(columnClicked.DataPropertyName);
				dgvPager.SortOrder = ListSortDirection.Ascending;
			}

            dgvLendings.Tag = columnClicked.DataPropertyName;
		}

	    private string GetSortByParameter(string dataPropertyName)
	    {
	        switch (dataPropertyName)
	        {
                case "Email":
	                return "Borrower.Email";
                case "Borrower":
	                return "Borrower.Email";
                case "Title":
	                return "Book.Title";
                case "DateLent":
                    return "DateLent";
                default:
                    throw new NotImplementedException("Column not added yet. WIP.");
	        }
	    }

		private void GetResultSetWithNewSearchParameters(GenericMessage<SearchLendingsViewModel> message)
		{
            ReloadView(this, new SearchLendingsEventArgs(
				message.Content.FilterMetaDataList,
				message.Content.Operation,
				dgvPager.PageSize,
				dgvPager.PageIndex,
				dgvPager.SortByColumn,
				dgvPager.SortOrder,
				message.Content.SelectedGridLendingId)
				);
			
			ReSyncGridAndPager();

			dgvPager.AdjustPreviousNextButtons(DataGridViewPager.PageSizeChangeSubmittedEvent);
		}


		private Lending GetSelectedLending()
		{
			Lending selectedLending = default (Lending);
			int selectedRowIndex = -1;

			if (!ReferenceEquals(null, dgvLendings.CurrentCell))
			{
				selectedRowIndex = dgvLendings.CurrentCell.RowIndex;
				selectedLending = dgvLendings.Rows[selectedRowIndex].DataBoundItem as Lending;
				if (selectedLending != null)
				{
					if (!PresenterBinder.ApplicationState.HasItem(Constants.SelectedGridLending))
						PresenterBinder.ApplicationState.AddItem(Constants.SelectedGridLending, selectedLending.Id);
				}
			}
			return selectedLending;
		}

	#region Page event-handlers and overrides

		protected override void OnLoad(System.EventArgs e)
		{
			base.OnLoad(e);

			PresenterBinder.MessageBus.Register(
				this,
				MessageIds.SearchLendingsMessage,
				new Action<GenericMessage<SearchLendingsViewModel>>(GetResultSetWithNewSearchParameters)
				);
			PresenterBinder.MessageBus.Register(
				this,
				MessageIds.GetFilterParametersResponse,
				new Action<GenericMessage<SearchLendingsViewModel>>(GetResultSetWithNewSearchParameters)
				);
		}

		private void dgvPager_PageSizeChanged(object sender, PagedEventArgs e)
		{
			var selectedGridLending = GetSelectedLending();

			if (!ReferenceEquals(selectedGridLending, null))
			{
				var selectedGridLendingId = selectedGridLending.Id;

				GetSearchParameters(selectedGridLendingId);
			}

			ReSyncGridAndPager();

			dgvPager.AdjustPreviousNextButtons(e.EventRaised);
		}

		private void dgvPager_PageChanged(object sender, PagedEventArgs e)
		{
			var selectedGridLending = GetSelectedLending();
			int selectedLendingId = -1;

			if (ReferenceEquals(null, selectedGridLending))
			{
				selectedLendingId = NoSelectedItem;
			}
			else
			{
				selectedLendingId = selectedGridLending.Id;
			}

			var searchLendingsViewModel = GetSearchParameters(selectedLendingId);

			ReSyncGridAndPager();

			dgvPager.AdjustPreviousNextButtons(e.EventRaised);
		}

		private void dgvLendings_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;

			if (columnIndex > -1)
			{

				var columnClicked = dgvLendings.Columns[e.ColumnIndex];

				//  if less than 0, must be the Header column.
				if (rowIndex < 0)
				{
					if (columnClicked.SortMode == DataGridViewColumnSortMode.Programmatic)
					{
						SortOutSorting(columnClicked);

						var selectedGridLending = GetSelectedLending();
						var selectedLendingId = selectedGridLending.Id;

						var searchLendingsViewModel = GetSearchParameters(selectedLendingId);

						ReSyncGridAndPager();
					}
				}
				else
				{
					if (PresenterBinder.ApplicationState.HasItem(Constants.SelectedGridLending))
						PresenterBinder.ApplicationState.RemoveItem<int>(Constants.SelectedGridLending);
				}
			}
		}

		private void btnAddPerson_Click(object sender, System.EventArgs e)
		{
			AddPerson(this, System.EventArgs.Empty);
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

	#endregion

	    public void HydrateWithDataOnFocus()
	    {
            var searchLendingsViewModel = GetSearchParameters(NoSelectedItem);

            ReSyncGridAndPager();

            dgvPager.AdjustPreviousNextButtons(Constants.StartUp);
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

            PresenterBinder.MessageBus.Unregister<GenericMessage<SearchLendingsViewModel>>(this, MessageIds.SearchLendingsMessage);
            PresenterBinder.MessageBus.Unregister<GenericMessage<SearchLendingsViewModel>>(this, MessageIds.GetFilterParametersResponse);

            base.Dispose(disposing);
        }
	}
}
