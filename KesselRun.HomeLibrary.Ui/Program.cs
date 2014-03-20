using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KesselRun.HomeLibrary.Mapper;
using KesselRun.HomeLibrary.Service;
using Microsoft.Practices.Unity;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace KesselRun.HomeLibrary.Ui
{
    static class Program
    {
        private static IUnityContainer _unityContainer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var autoMapperBootstrapper = new MapperBootstrapper();
            autoMapperBootstrapper.Initialize();

            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<IHomeLibraryService, HomeLibraryService>(new TransientLifetimeManager());
            PresenterBinder.Factory = new UnityPresenterFactory(_unityContainer);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PersonView());
        }
    }
}
