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
        private int _pageIndex;

        const string BehaviourCategory = "Behaviour";
        const string ButtonNextPage = "btnNextPage";
        const string ButtonPreviousPage = "btnPreviousPage";
        const string NextPageSubmittedEvent = "NextPageSubmitted";
        const string PreviousPageSubmittedEvent = "PreviousPageSubmitted";

        [Category(BehaviourCategory), Description("The amount .")]
        public int PagerIncrement { get; set; }
        [Category(BehaviourCategory), Description("The page index.")]
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged();
            }
        }
        [Category(BehaviourCategory), Description("The page size.")]
        public int PageSize { get; set; }
        [Category(BehaviourCategory), Description("The page count.")]
        public int PageCount { get; set; }
        [Category(BehaviourCategory), Description("The column on which the grid's data is sorted.")]
        public string SortByColumn { get; set; }
        [Category(BehaviourCategory), Description("Whether sort order is asc or desc.")]
        public ListSortDirection SortOrder { get; set; }

        public event EventHandler<PagedEventArgs> NextPageSubmitted;
        public event EventHandler<PagedEventArgs> PreviousPageSubmitted;

        public DataGridViewPager()
        {
            InitializeComponent();

            btnPreviousPage.Enabled = false;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);


            InitializePageSizeDropdown();

            txtPageNumber.DataBindings.Add("Text", this, "PageIndex");
        }

        private void InitializePageSizeDropdown()
        {
            for (int i = 1; i <= PageCount; i++)
            {
                if (i%PagerIncrement == 0)
                    cboPageSize.Items.Add(i);
            }

            cboPageSize.SelectedIndex = 0;
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

                NextPageSubmitted(this, new PagedEventArgs(fromPageIndex, PageIndex, NextPageSubmittedEvent));
            }
            else
            {
                if (PageIndex == PageCount)
                    ToggleButton(ButtonNextPage, true);

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
                    int.TryParse(
                        cboPageSize.Text, 
                        NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                        null, out pageSize);
                    PageSize = pageSize;
                    NextPageSubmitted(this, new PagedEventArgs(fromPageNumber, 1, NextPageSubmittedEvent));
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
                }
                
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboPageSize_KeyUp(object sender, KeyEventArgs e)
        {
            //char keyEntered = (char) e.KeyValue;

            //if (char.IsControl(keyEntered) && !char.IsDigit(keyEntered))
            //{
            //    e.Handled = true;
            //    return;
            //}

            //int fromPageNumber = PageIndex;
            //int pageNumber;

            //if (int.TryParse(txtPageNumber.Text,
            //    NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            //    null, out pageNumber))
            //{
            //    PageSize = int.Parse(cboPageSize.Text);
            //    NextPageSubmitted(this, new PagedEventArgs(fromPageNumber, 1, NextPageSubmittedEvent));
            //}
        }

        private void cboPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            
            //char keyEntered = (char) e.KeyValue;

            //if (keyEntered == (char) 13)
            //{
            //    int fromPageNumber = PageIndex;
            //    int pageNumber;

            //    if (int.TryParse(txtPageNumber.Text,
            //        NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            //        null, out pageNumber))
            //    {
            //        PageSize = int.Parse(cboPageSize.Text);
            //        NextPageSubmitted(this, new PagedEventArgs(fromPageNumber, 1, NextPageSubmittedEvent));
            //    }
            //}
            
            //if (!char.IsControl(keyEntered) && !char.IsDigit(keyEntered))
            //{
            //    e.SuppressKeyPress = true;
            //    e.Handled = true;
            //}
        }
    }
}
