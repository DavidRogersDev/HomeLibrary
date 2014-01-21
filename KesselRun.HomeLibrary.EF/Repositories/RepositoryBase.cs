using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace KesselRun.HomeLibrary.EF.Repositories
{
    public abstract class RepositoryBase<T, TCxt> : IDisposable
        where T : class
        where TCxt : DbContext, new()
    {
        public DbContext Context;
        public DbSet<T> Items;

        protected RepositoryBase()
            : this(new TCxt())
        {
            
        }

        protected RepositoryBase(TCxt context)
        {
            Context = context;
            Items = Context.Set<T>();
        }

        public T Create()
        {
            CheckDisposed();
            return Items.Create();
        }

        public void Add(T item)
        {
            CheckDisposed();
            Items.Add(item);
            Context.SaveChanges();
        }

        public void Remove(T item)
        {
            CheckDisposed();
            Items.Remove(item);
            Context.SaveChanges();            
        }

        public void Update(T item)
        {
            CheckDisposed();

            var entry = Context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                Items.Attach(item);
                entry.State = EntityState.Modified;
            }
            Context.SaveChanges();            
        }


        public T GetById(int id)
        {
            CheckDisposed();
            var set = Items.Find(id);
            return set;
        }
        
        public IList<T> GetAll()
        {
            CheckDisposed();
            return Items.ToList();
        }

        public abstract void CheckDisposed();

        public void Dispose()
        {
            if (!Context.TryDispose()) return;
            Context = null;
            Items = null;
        }
    }
}
