using System;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Messaging;
using KesselRun.HomeLibrary.UiLogic.Views;
using KesselRun.HomeLibrary.UiModel;
using KesselRun.HomeLibrary.UiModel.ViewModels;
using WinFormsMvp.Binder;
using WinFormsMvp.Messaging;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    public partial class PeopleSearchCriteriaControl : UserControl, ISearchPeopleView
    {
        public PeopleSearchCriteriaControl()
        {
            InitializeComponent();

            PresenterBinder.MessageBus.Register(
                this, 
                MessageIds.GetFilterParametersRequestPeople, new Action<GenericMessage<SearchPeopleViewModel>>(GetFilterCriteria)
                );

        }

        private void GetFilterCriteria(GenericMessage<SearchPeopleViewModel> message)
        {
            message.Content.FilterMetaDataList.Add(new FilterMetaData
            {
                FilterBy = "FirstName",
                FilterValue = txtFirstName.Text.Trim()
            });

            PresenterBinder.MessageBus.Send(new GenericMessage<SearchPeopleViewModel>(message.Content), MessageIds.GetFilterParametersLendingsResponse);
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

            PresenterBinder.MessageBus.Unregister<GenericMessage<SearchPeopleViewModel>>(this, MessageIds.GetFilterParametersRequestPeople);

            base.Dispose(disposing);
        }
    }
}
