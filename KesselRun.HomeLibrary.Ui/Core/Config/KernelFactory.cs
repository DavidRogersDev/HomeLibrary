using Ninject;
using Ninject.Modules;

namespace KesselRun.HomeLibrary.Ui.Core.Config
{
    public class KernelFactory
    {
        private IKernel _kernel;

        public IKernel GetKernel()
        {
            if (ReferenceEquals(null, _kernel))
            {
                INinjectModule module = new HomeLibraryModule();
                _kernel = new StandardKernel(module);
            }

            return _kernel;
        }
    }
}
