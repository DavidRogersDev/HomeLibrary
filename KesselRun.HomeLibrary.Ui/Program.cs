using System;
using System.Data.Entity;
using System.Windows.Forms;
using AutoMapper;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.Mapper;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service;
using Microsoft.Practices.Unity;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace KesselRun.HomeLibrary.Ui
{
    static class Program
    {
        private static IUnityContainer _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new HomeLibraryInitializer());
            new HomeLibraryContext().Database.Initialize(true);

            var autoMapperBootstrapper = new MapperBootstrapper();
            autoMapperBootstrapper.Initialize();

            _container = new UnityContainer();

            _container.RegisterInstance<IMappingEngine>(AutoMapper.Mapper.Engine)
                .RegisterType<IUniversalMapper, UniversalMapper>(new TransientLifetimeManager());

            _container.RegisterType<IRepositoryProvider, RepositoryProvider>(
                new TransientLifetimeManager(),
                new InjectionMember[] { new InjectionConstructor(new RepositoryFactories()) }
                );

            _container.RegisterType<IUnitOfWork, UnitOfWork>(new TransientLifetimeManager());
            _container.RegisterType<IHomeLibraryService, HomeLibraryService>(new TransientLifetimeManager());

            PresenterBinder.Factory = new UnityPresenterFactory(_container);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PersonView());
        }
    }
}
