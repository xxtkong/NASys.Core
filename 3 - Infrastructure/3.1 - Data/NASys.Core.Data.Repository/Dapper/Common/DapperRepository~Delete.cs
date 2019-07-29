using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual void Delete(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await  _dbConnection["write"].DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }


        public virtual void Delete(IEnumerable<TEntity> entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(IEnumerable<TEntity> entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await _dbConnection["write"].DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }

        public virtual void Delete(IPredicate entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(IPredicate entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await  _dbConnection["write"].DeleteAsync(entity);
            else
               await transaction.Connection.DeleteAsync(entity, transaction);
        }

        public virtual void Delete(object entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Delete(entity);
            else
                transaction.Connection.Delete(entity, transaction);
        }
        public virtual async Task DeleteAsync(object entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection["write"].DeleteAsync(entity);
            else
                await transaction.Connection.DeleteAsync(entity, transaction);
        }
    }
}
