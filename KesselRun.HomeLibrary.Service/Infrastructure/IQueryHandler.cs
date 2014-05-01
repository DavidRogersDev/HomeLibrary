
using System;

namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface IQueryHandler<in TQuery, out TResult> : IDisposable 
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
