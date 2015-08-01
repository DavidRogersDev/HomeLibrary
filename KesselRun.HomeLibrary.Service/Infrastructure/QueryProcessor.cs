using System.Diagnostics;
using Microsoft.Practices.Unity;
using System;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor, IDisposable
    {
        private readonly IUnityContainer _container;
        private bool _disposed;

        public QueryProcessor(IUnityContainer container)
        {
            _container = container;
        }

        //[DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.Resolve(handlerType, Constants.QueryProfiler);

            return handler.Handle((dynamic)query);
        }

        public void Dispose()
        {
            Trace.TraceInformation("Unity obj in QP " + _container.GetHashCode().ToString());
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _container.Dispose();
                _disposed = true;
            }            
        }
    }
}
