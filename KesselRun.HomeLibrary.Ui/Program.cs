using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Ui.Forms;

namespace KesselRun.HomeLibrary.Ui
{
    static class Program
    {
        private static DiContainerConfigurer diContainerConfigurer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            diContainerConfigurer = new DiContainerConfigurer(mainForm);
            diContainerConfigurer.Configure();

            Application.Run(mainForm);
        }
    }
}
