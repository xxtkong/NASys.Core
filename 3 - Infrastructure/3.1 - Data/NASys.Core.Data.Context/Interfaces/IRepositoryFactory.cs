using NASys.Core.Domain.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Context.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
    }
}
