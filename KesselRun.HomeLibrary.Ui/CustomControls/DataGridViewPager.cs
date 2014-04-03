using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KesselRun.HomeLibrary.Ui.CustomControls
{
    public partial class DataGridViewPager : UserControl
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

        public DataGridViewPager()
        {
            InitializeComponent();
        }
        
        public string PageInfoText
        {
            set { txtPagingInfo.Text = string.Format("{0} of {1}", PageIndex, PageCount); }
        }

        public event EventHandler NextPageSubmitted;

        protected virtual void OnNextPageSubmitted()
        {
            EventHandler handler = NextPageSubmitted;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        //private void btnNextPage_Click(object sender, EventArgs e)
        //{
        //    NextPageSubmitted(this, EventArgs.Empty);
        //}
    }
}
