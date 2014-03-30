using KesselRun.HomeLibrary.Common.Contracts;
using KesselRun.HomeLibrary.UiLogic.Services;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Ui
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private readonly IWindow _mainWindow;
        private readonly IUnityContainer _container = new UnityContainer();

        public DiContainerConfigurer(IWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Configure()
        {
            //_container.RegisterType<INavigationService, NavigationService>(new TransientLifetimeManager(), new InjectionConstructor(_mainWindow));
        }
    }
}