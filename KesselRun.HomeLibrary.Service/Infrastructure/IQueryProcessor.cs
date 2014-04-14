
namespace KesselRun.HomeLibrary.Service.Infrastructure
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}
