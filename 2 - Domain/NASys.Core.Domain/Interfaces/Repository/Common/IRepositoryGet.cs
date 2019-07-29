using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.Domain.Interfaces.Repository.Common
{
    public interface IRepositoryGet<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        Task<TEntity> FindAsync(int id);
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        IEnumerable<TEntity> Get(IFieldPredicate where);
        IEnumerable<TEntity> Get(object predicate);
    }
}
