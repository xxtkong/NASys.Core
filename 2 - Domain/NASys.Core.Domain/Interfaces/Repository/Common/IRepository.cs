using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using static Dapper.SqlMapper;

namespace NASys.Core.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 方式1：var predicate = Predicates.Field<Person>(f => f.Active, Operator.Eq, true);
        /// 方式2：var predicate = new { Active = true, FirstName = "c" };
        /// 方式3：var predicate = new { FirstName = new[] { "b", "d" } };
        /// 方式4：var predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() }; 
        ///        predicate.Predicates.Add(Predicates.Field<Person>(f => f.FirstName, Operator.Eq, "%1111%"));   
        /// </summary>
        /// <param name="predicate">例：</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(object predicate = null, IDbTransaction transaction = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TEntity Find(int id,IDbTransaction transaction = null);
        TEntity Find(int id, CommittableTransaction transaction);
        Task<TEntity> FindAsync(int id, IDbTransaction transaction = null);
        int Count(object predicate = null, IDbTransaction transaction = null);
        int Insert(TEntity entity,IDbTransaction transaction = null);
        int Insert(TEntity entity, CommittableTransaction transaction);
        void Insert(IEnumerable<TEntity> entities, IDbTransaction transaction = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities">new[] { a1, a2, a3 }</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        dynamic Insert(TEntity[] entities, IDbTransaction transaction = null);
        Task InsertAsync(params TEntity[] entities);
        void Update(TEntity entity, IDbTransaction transaction = null);
        void Update(TEntity[] entities, IDbTransaction transaction = null);
        void Update(IEnumerable<TEntity> entities, IDbTransaction transaction = null);
        void Delete(TEntity entity, IDbTransaction transaction = null);
        void Delete(IEnumerable<TEntity> entity, IDbTransaction transaction = null);
        IEnumerable<TEntity> FromSql(string sql, params object[] parameters);
        IDbTransaction GetdbTransaction(DbConnection dbConnection);
        DbConnection GetFirstConnection(string key = null);
        Task<IEnumerable<TEntity>> GetAllAsync(object predicate = null, IDbTransaction transaction = null);
        /// <summary>
        /// IList<ISort> sort = new List<ISort>
        /// {
        ///      Predicates.Sort<Person>(p => p.LastName),
        ///      Predicates.Sort<Person>(p => p.FirstName)
        /// };
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetPage(int page, int pageSize, IList<ISort> sorts, object predicate = null, IDbTransaction transaction = null);
        Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize, IList<ISort> sorts, object predicate = null, IDbTransaction transaction = null);
        /// <summary>
        /// GetMultiplePredicate predicate = new GetMultiplePredicate();
        /// predicate.Add<Person>(null);
        /// predicate.Add<Animal>(Predicates.Field<Animal>(a => a.Name, Operator.Like, "Ba%"));
        /// predicate.Add<Person>(Predicates.Field<Person>(a => a.LastName, Operator.Eq, "c1"));
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns>result.Read<Person>();result.Read<Animal>();result.Read<Person>()</returns>
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate = null, IDbTransaction transaction = null);
        IEnumerable<TEntity> GetFromSql(string sql, object param = null, IDbTransaction transaction = null);
        Task<IEnumerable<TEntity>> GetFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null);
        GridReader GetMultipleFromSql(string sql, object param = null, IDbTransaction transaction = null);
        Task<GridReader> GetMultipleFromSqlAsync(string sql, object param = null, IDbTransaction transaction = null);
        IEnumerable<dynamic> GetDynamic(string sql, object param, IDbTransaction transaction = null);
        Task<IEnumerable<dynamic>> GetDynamicAsync(string sql, object param, IDbTransaction transaction = null);
        Task<int> InsertAsync(TEntity entity, IDbTransaction transaction = null);
        Task<dynamic> InsertAsync(TEntity[] entities, IDbTransaction transaction = null);
        Task InsertAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null);
        Task DeleteAsync(IEnumerable<TEntity> entity, IDbTransaction transaction = null);
        Task DeleteAsync(TEntity entity, IDbTransaction transaction = null);
        void Delete(IPredicate entity, IDbTransaction transaction = null);
        Task DeleteAsync(IPredicate entity, IDbTransaction transaction = null);
        void Delete(object entity, IDbTransaction transaction = null);
        Task DeleteAsync(object entity, IDbTransaction transaction = null);
        Task UpdateAsync(TEntity entity, IDbTransaction transaction = null);
        Task UpdateAsync(TEntity[] entities, IDbTransaction transaction = null);
        Task UpdateAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null);
        int Execute(string sql, object param, IDbTransaction transaction = null);
        Task<int> ExecuteAsync(string sql, object param, IDbTransaction transaction = null);
        object ExecuteScalar(string sql, object param, IDbTransaction transaction = null);
        Task<object> ExecuteScalarAsync(string sql, object param, IDbTransaction transaction = null);
    }
}
