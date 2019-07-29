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
        public virtual void Update(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Update(entity);
            else
                transaction.Connection.Update(entity, transaction);
        }

        public virtual async Task UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            if (transaction == null)
               await  _dbConnection["write"].UpdateAsync(entity);
            else
               await  transaction.Connection.UpdateAsync(entity, transaction);
        }
        public virtual void Update(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                 _dbConnection["write"].Update(entities);
            else
                 transaction.Connection.Update(entities, transaction);
        }
        public virtual async Task UpdateAsync(TEntity[] entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection["write"].UpdateAsync(entities);
            else
                await transaction.Connection.UpdateAsync(entities, transaction);
        }
        public virtual void Update(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                _dbConnection["write"].Update(entities);
            else
                transaction.Connection.Update(entities, transaction);
        }
        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null)
        {
            if (transaction == null)
                await _dbConnection["write"].UpdateAsync(entities);
            else
                await transaction.Connection.UpdateAsync(entities, transaction);
        }
    }
}
