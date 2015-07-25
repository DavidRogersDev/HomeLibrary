using KesselRun.HomeLibrary.Ui.Messaging;
using KesselRun.HomeLibrary.UiLogic.Presenters;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using System;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Forms;
using WinFormsMvp.Messaging;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    [PresenterBinding(typeof(SearchLendingsPresenter))]
    public partial class LendingsSearchCriteriaControl : MvpUserControl, ISearchLendingsView
    {
        public LendingsSearchCriteriaControl()
        {
            InitializeComponent();

            PresenterBinder.MessageBus.Register(this, MessageIds.GetFilterParametersRequest,
                new Action<GenericMessage<SearchLendingsViewModel>>((m) =>
                {
                    m.Content.Filter = txtSearchFilter.Text.Trim();
                    m.Content.FilterBy = GetFilterByParameter();
                    m.Content.Operation = string.Empty;

                    PresenterBinder.MessageBus.Send(new GenericMessage<SearchLendingsViewModel>(m.Content), MessageIds.GetFilterParametersResponse);
                }));

        }

        #region ISearchLendingsView Members

        public event EventHandler ViewClosing;
        public event EventHandler CloseControl;
        public event EventHandler SendSearchLendingsMessage;
        public SearchLendingsViewModel SearchLendingsViewModel { get; set; }

        #endregion


        private void btnExecuteSearch_Click(object sender, System.EventArgs e)
        {
            var filterBy = GetFilterByParameter();

            SearchLendingsViewModel = new SearchLendingsViewModel
            {
                Filter = txtSearchFilter.Text.Trim(),
                FilterBy = filterBy,
                Operation = string.Empty
            };

            PresenterBinder.MessageBus.Send(new GenericMessage<SearchLendingsViewModel>(SearchLendingsViewModel), MessageIds.SearchLendingsMessage);
        }

        private string GetFilterByParameter()
        {
            string filterBy = string.Empty;

            if (radByBorrower.Checked)
            {
                filterBy = "Borrower.FirstName";
            }
            else
            {
                filterBy = "Book.Title";
            }
            return filterBy;
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void LogEventToView(LogEvent logEvent)
        {
            throw new NotImplementedException();
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

            PresenterBinder.MessageBus.Unregister<GenericMessage<SearchLendingsViewModel>>(this, MessageIds.GetFilterParametersRequest);

            base.Dispose(disposing);
        }

    }
}
