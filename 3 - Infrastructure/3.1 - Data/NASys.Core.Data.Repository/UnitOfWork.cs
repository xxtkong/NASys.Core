using Microsoft.EntityFrameworkCore.Infrastructure;
using NASys.Core.Data.Context;
using NASys.Core.Data.Context.Interfaces;
using NASys.Core.Data.Repository.EntityFramework.Common;
using NASys.Core.Domain.Interfaces.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork, IRepositoryFactory
    {
        private readonly NASysContext _context;
        public UnitOfWork(NASysContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        private Dictionary<Type, object> repositories;
        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }
            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context,_context.NASysDapperConnection);
            }

            return (IRepository<TEntity>)repositories[type];
        }
    }
}
