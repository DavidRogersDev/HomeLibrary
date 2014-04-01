using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using KesselRun.HomeLibrary.EF.Db;
using KesselRun.HomeLibrary.Model.Contracts;
using KesselRun.HomeLibrary.Model.Enums;

namespace KesselRun.HomeLibrary.EF
{
    public class DisconnectedPropertyChangeHelper
    {
        private readonly HomeLibraryContext _context;

        public DisconnectedPropertyChangeHelper(IEntitiesContext context)
        {
            _context = (HomeLibraryContext)context;
        }

        public void ApplyChanges<TEntity>(TEntity root)
            where TEntity : class, IObjectWithState
        {
            _context.Set<TEntity>().Add(root);
            CheckForEntitiesWithoutStateInterface(_context);

            foreach (var entry in _context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState entityWithStateInfo = entry.Entity;
                entry.State = ConvertState(entityWithStateInfo.State);
                if (entityWithStateInfo.State == State.Unchanged)
                {
                    ApplyPropertyChanges(entry.OriginalValues, entityWithStateInfo.OriginalValues);
                }
            }
            _context.SaveChanges();
        }

        public EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        private void ApplyPropertyChanges(DbPropertyValues values, Dictionary<string, object> originalValues)
        {
            foreach (var originalValue in originalValues)
            {
                if (originalValue is Dictionary<string, object>)
                {
                    ApplyPropertyChanges(
                        (DbPropertyValues) values[originalValue.Key],
                        (Dictionary<string, object>) originalValue.Value
                        );
                }
                else
                {
                    values[originalValue.Key] = originalValue.Value;
                }
            }
        }

        private void CheckForEntitiesWithoutStateInterface(IEntitiesContext context)
        {
            var entitiesWithoutState = from entry in _context.ChangeTracker.Entries()
                                       where !(entry.Entity is IObjectWithState)
                                       select entry;

            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException("All entities must implement IObjectWithState");
            }
        }

    }
}