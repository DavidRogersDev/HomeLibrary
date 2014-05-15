using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Core;

namespace KesselRun.HomeLibrary.Ui.UserControls
{
    public partial class TmpControl2 : UserControl, ILikeThisViewALot
    {
        private readonly Navigator _navigator = Navigator.SingleNavigator;

        public TmpControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _navigator.Return(Parent);
            
        }
    }

    public interface ILikeThisViewALot
    {
    }
}
