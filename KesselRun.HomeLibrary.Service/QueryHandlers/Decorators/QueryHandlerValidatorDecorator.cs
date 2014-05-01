using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using KesselRun.HomeLibrary.Service.Infrastructure;

namespace KesselRun.HomeLibrary.Service.QueryHandlers.Decorators
{
    public class QueryHandlerValidatorDecorator <TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;

        //[DebuggerStepThrough]
        public QueryHandlerValidatorDecorator(IQueryHandler<TQuery, TResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        //[DebuggerStepThrough]
        public TResult Handle(TQuery query)
        {
            var validationContext = new ValidationContext(query);

            try
            {
                Validator.ValidateObject(query, validationContext, true);
                return _queryHandler.Handle(query);
            }
            catch (ValidationException validationException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _queryHandler.Dispose();
        }
    }
}
