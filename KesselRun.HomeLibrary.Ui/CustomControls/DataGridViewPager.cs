using System;
using System.ComponentModel;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;

namespace KesselRun.HomeLibrary.Ui.CustomControls
{
    public partial class DataGridViewPager : UserControl
    {
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

        private void btnNextPage_Click(object sender, System.EventArgs e)
        {
            var fromPageIndex = PageIndex;

            //if (PageIndex < PageCount)
            //{
            //    if (PageIndex == 1)
            //    {
            //        btnPreviousPage.Enabled = true;
            //    }

            //    PageIndex++;

            //    if (PageIndex == PageCount)
            //        btnNextPage.Enabled = false;
            //}

            OnNextPageSubmitted(new PagedEventArgs(fromPageIndex, PageIndex, "NextPageSubmitted"));
        }

        private void btnPreviousPage_Click(object sender, System.EventArgs e)
        {
            var fromPageIndex = PageIndex;

            //if (PageIndex > 0)
            //{

            //    if (PageIndex == PageCount)
            //        btnNextPage.Enabled = true;

            //    PageIndex--;

            //    if (PageIndex == 1)
            //    {
            //        btnPreviousPage.Enabled = false;
            //    }
                
            //}

            OnPreviousPageSubmitted(new PagedEventArgs(fromPageIndex, PageIndex, "PreviousPageSubmitted"));
        }

        //private void btnNextPage_Click(object sender, EventArgs e)
        //{
        //    NextPageSubmitted(this, EventArgs.Empty);
        //}

        public void AdjustPreviousNextButtons(string eventRaised)
        {
            switch (eventRaised)
            {
                case "NextPageSubmitted":
                    {
                        if (PageIndex < PageCount)
                        {
                            if (PageIndex == 1)
                                ToggleButton("btnPreviousPage", true);

                            PageIndex++;

                            if (PageIndex == PageCount)
                                ToggleButton("btnNextPage", false);
                        }
                        break;
                    }
                case "PreviousPageSubmitted":
                    {
                        if (PageIndex > 0)
                        {

                            if (PageIndex == PageCount)
                                ToggleButton("btnNextPage", true);

                            PageIndex--;

                            if (PageIndex == 1)
                                ToggleButton("btnPreviousPage", false);

                        }

                        break;
                    }
                default:
                {
                    ToggleButton("btnPreviousPage", false);
                    break;
                }
            }
        }


        public void ToggleButton(string buttonName, bool enable)
        {
            switch (buttonName)
            {
                case "btnNextPage":
                    btnNextPage.Enabled = enable;
                    break;
                case "btnPreviousPage":
                    btnPreviousPage.Enabled = enable;
                    break;
            }
        }
    }
}
