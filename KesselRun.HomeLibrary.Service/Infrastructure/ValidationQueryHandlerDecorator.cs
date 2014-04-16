using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public class ValidationQueryHandlerDecorator <TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decorated;

        [DebuggerStepThrough]
        public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            _decorated = decorated;
        }

        //[DebuggerStepThrough]
        public TResult Handle(TQuery query)
        {
            var validationContext = new ValidationContext(query);
            try
            {
                Validator.ValidateObject(query, validationContext, true);
            }
            catch (Exception exception)
            {
                
            }

            return _decorated.Handle(query);
        }
    }
}
