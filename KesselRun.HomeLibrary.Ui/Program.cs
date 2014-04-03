using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.Ui.Core;
using KesselRun.HomeLibrary.Ui.Forms;

namespace KesselRun.HomeLibrary.Ui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            BoostrapStartupServices();

            var mainForm = new MainForm();
            
     

            Application.Run(mainForm);
        }

        static void BoostrapStartupServices()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var exportedType in assembly.GetExportedTypes())
            {
                if (!typeof (IBootstrapper).IsAssignableFrom(exportedType)) continue;
                var constructors = exportedType.GetConstructors();
                var bootstrapper = constructors[0].Invoke(new object[] {});
                ((IBootstrapper) bootstrapper).Configure();
            }            
        }
    }
}
