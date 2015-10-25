using System.Linq;
using System.Windows.Forms;
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

            PresenterBinder.MessageBus.Register(this, MessageIds.GetFilterParametersRequest, new Action<GenericMessage<SearchLendingsViewModel>>(GetFilterCriteria));
        }

        #region ISearchLendingsView Members

        public event EventHandler ViewClosing;
        public event EventHandler CloseControl;
        public event EventHandler SendSearchLendingsMessage;
        public SearchLendingsViewModel SearchLendingsViewModel { get; set; }

        #endregion


        private void btnExecuteSearch_Click(object sender, System.EventArgs e)
        {
            SearchLendingsViewModel = new SearchLendingsViewModel();

            GetFiltersFromControls(SearchLendingsViewModel);

            PresenterBinder.MessageBus.Send(new GenericMessage<SearchLendingsViewModel>(SearchLendingsViewModel), MessageIds.SearchLendingsMessage);
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void LogEventToView(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }

        private void GetFilterCriteria(GenericMessage<SearchLendingsViewModel> message)
        {
            GetFiltersFromControls(message.Content);

            PresenterBinder.MessageBus.Send(new GenericMessage<SearchLendingsViewModel>(message.Content), MessageIds.GetFilterParametersResponse);
        }

        private void GetFiltersFromControls(SearchLendingsViewModel viewModel)
        {
            grpSearchGroup.Controls.OfType<CheckBox>().ToList().ForEach(
                chk =>
                {
                    if (chk.Checked)
                    {
                        viewModel.FilterMetaDataList.Add(new FilterMetaData
                        {
                            FilterBy = chk.Tag.ToString(),
                            FilterValue = txtSearchFilter.Text.Trim()
                        });
                    }
                });
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
