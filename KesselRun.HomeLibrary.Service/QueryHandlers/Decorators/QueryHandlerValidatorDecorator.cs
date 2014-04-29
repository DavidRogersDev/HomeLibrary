using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using KesselRun.HomeLibrary.Service.Infrastructure;

namespace KesselRun.HomeLibrary.Service.QueryHandlers.Decorators
{
    public class QueryHandlerValidatorDecorator <TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decorated;

        [DebuggerStepThrough]
        public QueryHandlerValidatorDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            _decorated = decorated;
        }

        [DebuggerStepThrough]
        public TResult Handle(TQuery query)
        {
            var validationContext = new ValidationContext(query);

            try
            {
                Validator.ValidateObject(query, validationContext, true);
                return _decorated.Handle(query);
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
    }
}
