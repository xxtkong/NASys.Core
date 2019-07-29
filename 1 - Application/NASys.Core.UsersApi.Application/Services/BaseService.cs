using NASys.Core.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.UsersApi.Application.Services
{
    public class BaseService<TContext>
    {
        private readonly IUnitOfWork _unitOfWork;
        public virtual void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
