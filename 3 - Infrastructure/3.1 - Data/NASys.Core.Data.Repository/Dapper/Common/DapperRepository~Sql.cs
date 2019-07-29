using Dapper;
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
        public virtual int Execute(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["write"].Execute(sql, param);
            else
                return transaction.Connection.Execute(sql, param, transaction);
        }
        public virtual async Task<int> ExecuteAsync(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["write"].ExecuteAsync(sql, param);
            else
                return await transaction.Connection.ExecuteAsync(sql, param, transaction);
        }
        public virtual object ExecuteScalar(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["write"].ExecuteScalar(sql, param);
            else
                return transaction.Connection.ExecuteScalar(sql, param, transaction);
        }
        public virtual async Task<object> ExecuteScalarAsync(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["write"].ExecuteScalarAsync(sql, param);
            else
                return await transaction.Connection.ExecuteScalarAsync(sql, param, transaction);
        }
    }
}
