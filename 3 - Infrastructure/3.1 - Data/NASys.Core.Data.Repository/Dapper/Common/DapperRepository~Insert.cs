using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NASys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual int Insert(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["write"].Insert(entity);
            else
                return transaction.Connection.Insert(entity, transaction);
        }
        public virtual async Task<int> InsertAsync(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["write"].InsertAsync(entity);
            else
                return await transaction.Connection.InsertAsync(entity, transaction);
        }

        public virtual int Insert(TEntity entity, CommittableTransaction transaction)
        {
            if (_dbConnection["write"].State == ConnectionState.Closed)
                _dbConnection["write"].Open();
            _dbConnection["write"].EnlistTransaction(transaction);
            return _dbConnection["write"].Insert(entity);
        }
        public virtual dynamic Insert(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return  _dbConnection["write"].Insert(entities);
            else
                return  transaction.Connection.Insert(entities, transaction);
        }
        public virtual async Task<dynamic> InsertAsync(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["write"].InsertAsync(entities);
            else
                return await transaction.Connection.InsertAsync(entities, transaction);
        }
        public virtual void Insert(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Insert(entities);
            else
                transaction.Connection.Insert(entities, transaction);
        }

        public virtual async Task InsertAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await _dbConnection["write"].InsertAsync(entities);
            else
              await transaction.Connection.InsertAsync(entities, transaction);
        }
    }
}
