using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF
{
    /// <summary>
    /// Interface for the "Unit of Work"
    /// </summary>
    public interface IUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IEntityRepository<Book> Books { get; }
        IEntityRepository<Person> People { get; }
        IEntityRepository<Lending> Lendings { get; }
    }
}