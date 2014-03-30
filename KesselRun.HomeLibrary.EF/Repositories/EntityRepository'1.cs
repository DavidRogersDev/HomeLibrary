using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.GenericRepository;

namespace KesselRun.HomeLibrary.EF.Repositories 
{
    
    /// <summary>
    /// IEntityRepository implementation for DbContext instance where the TId type is Int32.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public class EntityRepository<TEntity> : EntityRepository<TEntity, int>, IEntityRepository<TEntity>
        where TEntity : class, IEntity<int> 
    {

        public EntityRepository(IEntitiesContext dbContext)
            : base(dbContext) { 

        }
    }
}