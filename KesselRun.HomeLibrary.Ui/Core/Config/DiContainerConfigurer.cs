using KesselRun.HomeLibrary.Common.Contracts;
using Ninject;
using WinFormsMvp.Binder;
using WinFormsMvp.Ninject;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class DiContainerConfigurer : IBootstrapper
    {
        public void Configure()
        {
            IKernel kernel = new KernelFactory().CreateKernel();
            PresenterBinder.Factory = new NinjectPresenterFactory(kernel);
        }
    }
}