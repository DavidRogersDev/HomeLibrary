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
        public string SortOrder { get; set; }

        public event EventHandler<NextPageEventArgs> NextPageSubmitted;

        protected virtual void OnNextPageSubmitted(NextPageEventArgs e)
        {
            EventHandler<NextPageEventArgs> handler = NextPageSubmitted;
            if (handler != null) handler(this, e);
        }

        public DataGridViewPager()
        {
            InitializeComponent();
        }

        public ListSortDirection GetSortDirection()
        {
            switch (SortOrder)
            {
                case "Asc": return ListSortDirection.Ascending;
                case "Desc": return ListSortDirection.Descending;
                default: return ListSortDirection.Ascending;
            }
        }

        public string PageInfoText
        {
            set { txtPagingInfo.Text = string.Format("{0} of {1}", PageIndex, PageCount); }
        }

        private void btnNextPage_Click(object sender, System.EventArgs e)
        {
            var fromPageIndex = PageIndex;

            if (PageIndex < PageCount)
            {
                if (PageIndex == 0)
                {
                    btnPreviousPage.Enabled = true;
                }

                PageIndex++;

                if (PageIndex == PageCount)
                    btnNextPage.Enabled = false;
            }

            OnNextPageSubmitted(new NextPageEventArgs(fromPageIndex, PageIndex));
        }

        //private void btnNextPage_Click(object sender, EventArgs e)
        //{
        //    NextPageSubmitted(this, EventArgs.Empty);
        //}
    }
}
