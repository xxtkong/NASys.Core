using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
