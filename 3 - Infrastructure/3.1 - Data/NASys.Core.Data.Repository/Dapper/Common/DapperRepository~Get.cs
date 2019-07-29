using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Dapper;
using static Dapper.SqlMapper;

namespace NASys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity>
    {
        public virtual int Count(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].Count<TEntity>(predicate);
            else
                return transaction.Connection.Count<TEntity>(predicate, transaction);
        }
        public virtual TEntity Find(int id, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].Get<TEntity>(id);
            else
                return transaction.Connection.Get<TEntity>(id,transaction);
        }
        public virtual TEntity Find(int id, CommittableTransaction transaction)
        {
            if (_dbConnection["read"].State == ConnectionState.Closed)
                _dbConnection["read"].Open();
            _dbConnection["read"].EnlistTransaction(transaction);
            return _dbConnection["read"].Get<TEntity>(id);
        }

        public virtual async Task<TEntity> FindAsync(int id,IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].GetAsync<TEntity>(id);
            else
                return await transaction.Connection.GetAsync<TEntity>(id,transaction);
        }

        public virtual IEnumerable<TEntity> GetAll(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].GetList<TEntity>(predicate);
            else
                return transaction.Connection.GetList<TEntity>(predicate, null, transaction);

        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].GetListAsync<TEntity>(predicate);
            else
                return await transaction.Connection.GetListAsync<TEntity>(predicate, null, transaction);
        }
        public virtual IEnumerable<TEntity> GetPage(int page, int pageSize, IList<ISort> sorts, object predicate = null,  IDbTransaction transaction = null)
        {
            if (transaction == null)
               return _dbConnection["read"].GetPage<TEntity>(predicate, sorts, page, pageSize);
            else
               return transaction.Connection.GetPage<TEntity>(predicate,sorts, page, pageSize, transaction);
        }
        public virtual async Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize, IList<ISort> sorts, object predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].GetPageAsync<TEntity>(predicate, sorts, page, pageSize);
            else
                return await transaction.Connection.GetPageAsync<TEntity>(predicate, sorts, page, pageSize, transaction);
        }

        public virtual IMultipleResultReader GetMultiple(GetMultiplePredicate predicate = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].GetMultiple(predicate);
            else
                return transaction.Connection.GetMultiple(predicate, transaction);
        }

        public virtual IEnumerable<TEntity> GetFromSql(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].Query<TEntity>(sql, param);
            else
                return transaction.Connection.Query<TEntity>(sql, param, transaction);
        }
        public virtual async Task<IEnumerable<TEntity>> GetFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].QueryAsync<TEntity>(sql, param);
            else
                return await transaction.Connection.QueryAsync<TEntity>(sql, param, transaction);
        }
        public virtual GridReader GetMultipleFromSql(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].QueryMultiple(sql, param);
            else
                return transaction.Connection.QueryMultiple(sql, param, transaction);
        }
        public virtual async Task<GridReader> GetMultipleFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].QueryMultipleAsync(sql, param);
            else
                return await transaction.Connection.QueryMultipleAsync(sql, param, transaction);
        }

        public IEnumerable<dynamic> GetDynamic(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return _dbConnection["read"].Query<dynamic>(sql, param);
            else
                return  transaction.Connection.Query<dynamic>(sql, param, transaction);
        }
        public async Task<IEnumerable<dynamic>> GetDynamicAsync(string sql, object param, IDbTransaction transaction = null)
        {
            if (transaction == null)
                return await _dbConnection["read"].QueryAsync<dynamic>(sql, param);
            else
                return await transaction.Connection.QueryAsync<dynamic>(sql, param, transaction);
        }
    }
}
