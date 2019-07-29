using NASys.Core.Domain.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DapperExtensions;
using System.Data;
using System.Linq;
using NASys.Core.Data.Context.Config;
using System.Data.Common;
using System.Transactions;
using NASys.Core.Data.Context;

namespace NASys.Core.Data.Repository.Dapper.Common
{
    public partial class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbConnectionFactory _dbConnection;
        public DapperRepository(DbConnectionFactory connection)
        {
            this._dbConnection = connection;
        }
       
        public IEnumerable<TEntity> FromSql(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public DbConnection GetFirstConnection(string key = null)
        {
            if (string.IsNullOrEmpty(key))
                //取第一条链接
                return _dbConnection.GetFirstConnection;
            else
                return _dbConnection[key];
        }
        public IDbTransaction GetdbTransaction(DbConnection dbConnection)
        {
            return dbConnection.BeginTransaction();
        }
        public Task InsertAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
