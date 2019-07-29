using Microsoft.EntityFrameworkCore;
using NASys.Core.Data.Repository.Dapper.Common;
using NASys.Core.Domain.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NASys.Core.Data.Repository.EntityFramework.Common
{
    public partial class Repository<TEntity> :  IRepositoryCRD<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IDbConnection _dbConnection;
        public Repository(DbContext dbContext,IDbConnection dbConnection)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Add(entity);
            
        }

        public void Insert(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        //protected readonly DbContext _dbContext;
        //protected readonly DbSet<TEntity> _dbSet;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        ///// </summary>
        ///// <param name="dbContext">The database context.</param>
        //public Repository(DbContext dbContext)
        //{
        //    _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        //    _dbSet = _dbContext.Set<TEntity>();
        //}
        ///// <summary>
        ///// Gets all entities. This method is not recommended
        ///// </summary>
        ///// <returns>The <see cref="IQueryable{TEntity}"/>.</returns>
        //[Obsolete("This method is not recommended, please use GetPagedList or GetPagedListAsync methods")]
        //public IQueryable<TEntity> GetAll()
        //{
        //    return _dbSet;
        //}
        ///// <summary>
        ///// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        ///// </summary>
        ///// <param name="sql">The raw SQL.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        //public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <returns>The found entity or null.</returns>
        //public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <returns>A <see cref="Task{TEntity}" /> that represents the asynchronous insert operation.</returns>
        //public virtual Task<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        ///// <summary>
        ///// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        ///// </summary>
        ///// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task{TEntity}"/> that represents the asynchronous find operation. The task result contains the found entity or null.</returns>
        //public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

        ///// <summary>
        ///// Gets the count based on a predicate.
        ///// </summary>
        ///// <param name="predicate"></param>
        ///// <returns></returns>
        //public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return _dbSet.Count();
        //    }
        //    else
        //    {
        //        return _dbSet.Count(predicate);
        //    }
        //}

        ///// <summary>
        ///// Inserts a new entity synchronously.
        ///// </summary>
        ///// <param name="entity">The entity to insert.</param>
        //public virtual void Insert(TEntity entity)
        //{
        //    var entry = _dbSet.Add(entity);
        //}

        ///// <summary>
        ///// Inserts a range of entities synchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        //public virtual void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

        ///// <summary>
        ///// Inserts a range of entities synchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        //public virtual void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        ///// <summary>
        ///// Inserts a new entity asynchronously.
        ///// </summary>
        ///// <param name="entity">The entity to insert.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task"/> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return _dbSet.AddAsync(entity, cancellationToken);

        //    // Shadow properties?
        //    //var property = _dbContext.Entry(entity).Property("Created");
        //    //if (property != null) {
        //    //property.CurrentValue = DateTime.Now;
        //    //}
        //}

        ///// <summary>
        ///// Inserts a range of entities asynchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        ///// <returns>A <see cref="Task" /> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        ///// <summary>
        ///// Inserts a range of entities asynchronously.
        ///// </summary>
        ///// <param name="entities">The entities to insert.</param>
        ///// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
        ///// <returns>A <see cref="Task"/> that represents the asynchronous insert operation.</returns>
        //public virtual Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddRangeAsync(entities, cancellationToken);

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public virtual void Update(TEntity entity)
        //{
        //    _dbSet.Update(entity);
        //}

        ///// <summary>
        ///// Updates the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        //public virtual void UpdateAsync(TEntity entity)
        //{
        //    _dbSet.Update(entity);

        //}

        ///// <summary>
        ///// Updates the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        ///// <summary>
        ///// Updates the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        ///// <summary>
        ///// Deletes the specified entity.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        ///// <summary>
        ///// Deletes the entity by the specified primary key.
        ///// </summary>
        ///// <param name="id">The primary key value.</param>
        //public virtual void Delete(object id)
        //{
        //    // using a stub entity to mark for deletion
        //    var typeInfo = typeof(TEntity).GetTypeInfo();
        //    var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
        //    var property = typeInfo.GetProperty(key?.Name);
        //    if (property != null)
        //    {
        //        var entity = Activator.CreateInstance<TEntity>();
        //        property.SetValue(entity, id);
        //        _dbContext.Entry(entity).State = EntityState.Deleted;
        //    }
        //    else
        //    {
        //        var entity = _dbSet.Find(id);
        //        if (entity != null)
        //        {
        //            Delete(entity);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Deletes the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        ///// <summary>
        ///// Deletes the specified entities.
        ///// </summary>
        ///// <param name="entities">The entities.</param>
        //public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
    }
}
