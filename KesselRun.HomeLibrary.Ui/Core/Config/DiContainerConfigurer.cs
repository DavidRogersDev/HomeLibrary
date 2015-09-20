using KesselRun.HomeLibrary.Common.Contracts;
using System.Reflection;
using Ninject;
using WinFormsMvp.Binder;
using WinFormsMvp.Ninject;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DiContainerConfigurer : IBootstrapper
    {
        private readonly Assembly _serviceAssembly = Assembly.Load("KesselRun.HomeLibrary.Service");
        private static IKernel _kernel;

        public DiContainerConfigurer()
        {
            
        }

        public void Configure()
        {
            _kernel = new KernelFactory().GetKernel();
            PresenterBinder.Factory = new NinjectPresenterFactory(_kernel);
        }
    }
}