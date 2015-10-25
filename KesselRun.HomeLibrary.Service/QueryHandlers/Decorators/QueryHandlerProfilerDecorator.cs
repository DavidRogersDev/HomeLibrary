using System;
using System.ComponentModel.DataAnnotations;
using KesselRun.HomeLibrary.Service.Infrastructure;

namespace KesselRun.HomeLibrary.Service.QueryHandlers.Decorators
{
    public class QueryHandlerProfilerDecorator <TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;
        private bool _disposed;

        //[DebuggerStepThrough]
        public QueryHandlerProfilerDecorator(IQueryHandler<TQuery, TResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        //[DebuggerStepThrough]
        public TResult Handle(TQuery query)
        {
            var validationContext = new ValidationContext(query);

            try
            {
                // do something
                return _queryHandler.Handle(query);
            }
            //catch (ValidationException validationException)
            //{
            //    throw;
            //}
            catch (Exception exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _queryHandler.Dispose();
            }

            _disposed = true;
        }
    }
}
