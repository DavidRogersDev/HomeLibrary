﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace KesselRun.HomeLibrary.GenericRepository {
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IComparable {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        PaginatedList<TEntity> Paginate(int pageIndex, int pageSize);

        TEntity GetSingle(TId id);
    }
}