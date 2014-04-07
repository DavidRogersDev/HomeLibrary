using AutoMapper;
using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service;
using Microsoft.Practices.Unity;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private readonly IUnityContainer _container = new UnityContainer();

        public DiContainerConfigurer()
        {
            
        }

        public void Configure()
        {
            PresenterBinder.Factory = new UnityPresenterFactory(_container);

            _container.RegisterType<INavigator, Navigator>(new TransientLifetimeManager());

            _container.RegisterInstance<IMappingEngine>(AutoMapper.Mapper.Engine)
                      .RegisterType<IUniversalMapper, UniversalMapper>(new TransientLifetimeManager());

            _container.RegisterType<IRepositoryProvider, RepositoryProvider>(
                new TransientLifetimeManager(), 
                new InjectionMember[] { new InjectionConstructor(new RepositoryFactories())}
                );

            _container.RegisterType<IUnitOfWork, UnitOfWork>(new TransientLifetimeManager());
            _container.RegisterType<ILendingsService, LendingsService>(new TransientLifetimeManager());
        }
    }
}