using System;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.EF.Repositories;
using KesselRun.HomeLibrary.EF.Repositories.Factories;
using KesselRun.HomeLibrary.GenericRepository;
using KesselRun.HomeLibrary.Model;

namespace KesselRun.HomeLibrary.EF
{
    /// <summary>
    /// The "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories". Each repository serves as a container dedicated to a particular root entity type such 
    /// as a <see cref="Person"/>. A repository typically exposes "Get" methods for querying and will offer add, update, and delete methods 
    /// if those features are supported. The repositories rely on their parent UoW to provide the interface to the data layer.
    /// </remarks>
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        private HomeLibraryContext DbContext { get; set; }

        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        // repositories
        public IEntityRepository<Book> Books { get { return GetStandardRepo<Book>(); } }
        public IEntityRepository<Person> People { get { return GetStandardRepo<Person>(); } }
        public IEntityRepository<Lending> Lendings { get { return GetStandardRepo<Lending>(); } }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new HomeLibraryContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // I don't need/want EF to perform validation
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        private IEntityRepository<T> GetStandardRepo<T>() where T : class, IEntity<int>
        {
            try
            {
                return RepositoryProvider.GetRepositoryForEntityType<T>();
            }
            catch (Exception e)
            {

            }

            return null;
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }


        #region IDisposable

        public void Dispose()
        {
            if (_disposed) return;

            if (!DbContext.TryDispose()) return;

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
