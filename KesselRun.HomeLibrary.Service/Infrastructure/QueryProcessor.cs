using System.Diagnostics;
using Microsoft.Practices.Unity;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IUnityContainer _container;

        public QueryProcessor(IUnityContainer container)
        {
            _container = container;
        }

        [DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.Resolve(handlerType, "Hi Dave");
            //dynamic handler = _container.Resolve(handlerType, string.Concat(handlerType.Name, "Registration"));

            return handler.Handle((dynamic)query);
        }
    }
}
