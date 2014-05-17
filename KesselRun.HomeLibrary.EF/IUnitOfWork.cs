using System;
using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF
{
    /// <summary>
    /// Interface for the "Unit of Work"
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        // Save pending changes to the data store.
        void Commit();

        IEntityRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;
    }
}