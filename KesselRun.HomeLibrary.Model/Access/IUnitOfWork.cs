namespace KesselRun.HomeLibrary.Model.Access
{
    /// <summary>
    /// Interface for the "Unit of Work"
    /// </summary>
    public interface IUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRepository<Person> People { get; }
        IRepository<Lending> Lendings { get; }
    }
}