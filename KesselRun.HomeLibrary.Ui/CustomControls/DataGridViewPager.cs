using System.Globalization;
using System.Runtime.CompilerServices;
using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Ui.CustomControls
{
    public partial class DataGridViewPager : UserControl, INotifyPropertyChanged
    {
        private int _pageCount;
        private int _pageSize;

        const string BehaviourCategory = "Behaviour";
        const string ButtonNextPage = "btnNextPage";
        const string ButtonPreviousPage = "btnPreviousPage";
        public const string NextPageSubmittedEvent = "NextPageSubmitted";
        public const string PageSizeChangeSubmittedEvent = "PageSizeChangeSubmitted";
        public const string PreviousPageSubmittedEvent = "PreviousPageSubmitted";

        [Category(BehaviourCategory), Description("The amount .")]
        public int PagerIncrement { get; set; }

        [Category(BehaviourCategory), Description("The page index.")]
        public int PageIndex { get; set; }

        [Category(BehaviourCategory), Description("The page size. This can be configured using the dropdown list.")]
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                OnPropertyChanged();
            }
        }

        [Category(BehaviourCategory), Description("The page count.")]
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                OnPropertyChanged();
            }
        }

        [Category(BehaviourCategory), Description("The column on which the grid's data is sorted.")]
        public string SortByColumn { get; set; }

        [Category(BehaviourCategory), Description("Whether sort order is asc or desc.")]
        public ListSortDirection SortOrder { get; set; }

        public event EventHandler<PagedEventArgs> NextPageSubmitted;
        public event EventHandler<PagedEventArgs> PageSizeChangeSubmitted;
        public event EventHandler<PagedEventArgs> PreviousPageSubmitted;

        public DataGridViewPager()
        {
            InitializeComponent();

            btnPreviousPage.Enabled = false;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            txtPageNumber.DataBindings.Add("Text", this, "PageIndex");
            lblTotalNumberPages.DataBindings.Add("Text", this, "PageCount");

            InitializePageSizeDropdown();
        }

        private void InitializePageSizeDropdown()
        {
            int indexToSelect = 0;

            for (int i = 1; i <= PageSize; i++)
            {
                if (i % PagerIncrement == 0)
                {
                    cboPageSize.Items.Add(i);
                    if (i == PageSize)
                        indexToSelect = cboPageSize.Items.Count - 1;
                }
            }

            cboPageSize.SelectedIndex = indexToSelect;

            cboPageSize.SelectionChangeCommitted += cboPageSize_SelectionChangeCommitted;
            cboPageSize.KeyPress += cboPageSize_KeyPress;
        }


        private void pageChange_Click(object sender, System.EventArgs e)
        {
            var fromPageIndex = PageIndex;

            var buttonClicked = sender as Button;

            Debug.Assert(buttonClicked != null, "buttonClicked != null");

            if (buttonClicked.Name.Equals(ButtonNextPage, StringComparison.OrdinalIgnoreCase))
            {
                //if (PageIndex == 1)
                    //ToggleButton(ButtonPreviousPage, true);

                PageIndex++;

                NextPageSubmitted(this, new PagedEventArgs(fromPageIndex, PageIndex, NextPageSubmittedEvent));
            }
            else
            {
                //if (PageIndex == PageCount)
                //    ToggleButton(ButtonNextPage, true);

                PageIndex--;

                PreviousPageSubmitted(this, new PagedEventArgs(fromPageIndex, PageIndex, PreviousPageSubmittedEvent));                
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
                case PageSizeChangeSubmittedEvent:
                {
                    if (PageIndex <= PageCount)
                    {
                        if (PageIndex == PageCount)
                            ToggleButton(btnNextPage.Name, false);
                        else
                            ToggleButton(btnNextPage.Name, true);
                    }

                    if (PageIndex > 0)
                    {
                        if (PageIndex == 1)
                            ToggleButton(btnPreviousPage.Name, false);
                        else    
                            ToggleButton(btnPreviousPage.Name, true);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void cboPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int fromPageNumber = PageIndex;
                int pageNumber;

                if (int.TryParse(txtPageNumber.Text,
                    NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                    null, out pageNumber))
                {
                    int pageSize;

                    if (int.TryParse(cboPageSize.Text,
                        NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                        null, out pageSize))
                    {
                        PageSize = pageSize;
                        PageSizeChangeSubmitted(this, new PagedEventArgs(fromPageNumber, -1, PageSizeChangeSubmittedEvent));
                    }
                }
                e.Handled = true;
            }
            

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                int fromPageNumber = PageIndex;
                int pageNumber;

                if (int.TryParse(txtPageNumber.Text, 
                    NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                    null, out pageNumber))
                {
                    PageIndex = pageNumber;

                    if (fromPageNumber < pageNumber)
                    {
                        NextPageSubmitted(this, new PagedEventArgs(fromPageNumber, pageNumber, NextPageSubmittedEvent));
                        
                        ToggleButton(ButtonPreviousPage, true);
                    }
                    else if (fromPageNumber > pageNumber)
                    {
                        PreviousPageSubmitted(this, new PagedEventArgs(fromPageNumber, pageNumber, PreviousPageSubmittedEvent));
                        ToggleButton(ButtonNextPage, true);
                    }
                    e.Handled = true;
                }
                
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboPageSize_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            int fromPageNumber = PageIndex;
            int pageNumber;

            if (int.TryParse(txtPageNumber.Text,
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                null, out pageNumber))
            {
                PageSize = int.Parse(cboPageSize.SelectedItem.ToString());
                PageSizeChangeSubmitted(this, new PagedEventArgs(fromPageNumber, -1, PageSizeChangeSubmittedEvent));
            }
        }

    }
}
