using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.Domain.Interfaces.Repository.Common
{
    public interface IRepositoryCRD<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Insert(params TEntity[] entities);
        void Insert(IEnumerable<TEntity> entities);
        Task InsertAsync(params TEntity[] entities);
        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);
    }
}
