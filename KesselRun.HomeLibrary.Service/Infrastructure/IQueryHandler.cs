
namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
