using System.Linq;

namespace KesselRun.HomeLibrary.Model.Access
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        T Create();
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}