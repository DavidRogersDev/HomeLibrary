using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Modules;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class KernelFactory
    {
        private IKernel _kernel;

        public IKernel CreateKernel()
        {
            if (ReferenceEquals(null, _kernel))
            {
                INinjectModule module = new HomeLibraryModule();

                _kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false }, new DynamicProxyModule(), module);
            }

            return _kernel;
        }
    }
}
