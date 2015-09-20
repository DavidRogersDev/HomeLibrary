using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace KesselRun.HomeLibrary.Service.ObjectResolution
{
    public class InjectionContainerFactory : IDisposable
    {
        private IKernel _kernel;
        private readonly Assembly _serviceAssembly;
        private bool _disposed;

        public InjectionContainerFactory(Assembly serviceAssembly)
        {
            _serviceAssembly = serviceAssembly;
        }

        public IKernel GetKernel()
        {
            if (ReferenceEquals(null, _kernel))
            {
                INinjectModule module = new ProcessorModule(_serviceAssembly);
                _kernel = new StandardKernel(module);
            }

            return _kernel;
        }

        public void Dispose()
        {
            //Trace.TraceInformation("Unity obj in QP " + _container.GetHashCode().ToString());
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _kernel.Dispose();
                _disposed = true;
            }
        }

    }
}
