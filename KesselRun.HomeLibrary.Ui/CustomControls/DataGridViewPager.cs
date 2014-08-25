using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Ui.CustomControls
{
    public partial class DataGridViewPager : UserControl
    {
        const string ButtonNextPage = "btnNextPage";
        const string ButtonPreviousPage = "btnPreviousPage";
        const string NextPageSubmittedEvent = "NextPageSubmitted";
        const string PreviousPageSubmittedEvent = "PreviousPageSubmitted";

        [Category("Behaviour"), Description("The page index.")]
        public int PageIndex { get; set; }
        [Category("Behaviour"), Description("The page size.")]
        public int PageSize { get; set; }
        [Category("Behaviour"), Description("The page count.")]
        public int PageCount { get; set; }
        [Category("Behaviour"), Description("The column on which the grid's data is sorted.")]
        public string SortByColumn { get; set; }
        [Category("Behaviour"), Description("Whether sort order is asc or desc.")]
        public ListSortDirection SortOrder { get; set; }

        public event EventHandler<PagedEventArgs> NextPageSubmitted;
        public event EventHandler<PagedEventArgs> PreviousPageSubmitted;

        protected virtual void OnNextPageSubmitted(PagedEventArgs e)
        {
            EventHandler<PagedEventArgs> handler = NextPageSubmitted;
            if (handler != null) handler(this, e);
        }        
        
        protected virtual void OnPreviousPageSubmitted(PagedEventArgs e)
        {
            EventHandler<PagedEventArgs> handler = PreviousPageSubmitted;
            if (handler != null) handler(this, e);
        }

        public DataGridViewPager()
        {
            InitializeComponent();

            btnPreviousPage.Enabled = false;
        }

        public string PageInfoText
        {
            set { txtPagingInfo.Text = string.Format("{0} of {1}", PageIndex, PageCount); }
        }

        private void pageChange_Click(object sender, System.EventArgs e)
        {
            var fromPageIndex = PageIndex;

            var buttonClicked = sender as Button;

            Debug.Assert(buttonClicked != null, "buttonClicked != null");

            if (buttonClicked.Name.Equals(ButtonNextPage, StringComparison.OrdinalIgnoreCase))
            {
                if (PageIndex == 1)
                    ToggleButton(ButtonPreviousPage, true);

                PageIndex++;

                OnNextPageSubmitted(new PagedEventArgs(fromPageIndex, PageIndex, NextPageSubmittedEvent));
            }
            else
            {
                if (PageIndex == PageCount)
                    ToggleButton(ButtonNextPage, true);

                PageIndex--;

                OnPreviousPageSubmitted(new PagedEventArgs(fromPageIndex, PageIndex, PreviousPageSubmittedEvent));                
            }
        }

        public void AdjustPreviousNextButtons(string eventRaised)
        {
            switch (eventRaised)
            {
                case NextPageSubmittedEvent:
                    {
                        if (PageIndex <= PageCount)
                        {
                            if (PageIndex == PageCount)
                                ToggleButton(btnNextPage.Name, false);
                        }
                        break;
                    }
                case PreviousPageSubmittedEvent:
                    {
                        if (PageIndex > 0)
                        {
                            if (PageIndex == 1)
                                ToggleButton(btnPreviousPage.Name, false);
                        }

                        break;
                    }
                default:
                {
                    ToggleButton(btnPreviousPage.Name, false);
                    break;
                }
            }
        }


        public void ToggleButton(string buttonName, bool enable)
        {
            switch (buttonName)
            {
                case ButtonNextPage:
                    btnNextPage.Enabled = enable;
                    break;
                case ButtonPreviousPage:
                    btnPreviousPage.Enabled = enable;
                    break;
            }
        }
    }
}
