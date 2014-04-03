using KesselRun.HomeLibrary.Common.Contracts;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Ui.Core
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private readonly IUnityContainer _container = new UnityContainer();

        public DiContainerConfigurer()
        {

        }

        public void Configure()
        {
            _container.RegisterType<INavigationService, NavigationService>(new TransientLifetimeManager());
        }
    }
}