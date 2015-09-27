using System;
using Ninject;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor, IDisposable
    {
        private readonly IKernel _kernel;
        private bool _disposed;
        private dynamic _queryHandler;

        public QueryProcessor(IKernel kernel)
        {
            _kernel = kernel;
        }

        //[DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            _queryHandler = _kernel.Get(handlerType);

            return _queryHandler.Handle((dynamic)query);
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
                if (!ReferenceEquals(_queryHandler, null))
                    _queryHandler.Dispose();
                _disposed = true;
            }            
        }
    }

    public interface IKernelFactory
    {
        IKernel RetrieveKernel();
    }
}
