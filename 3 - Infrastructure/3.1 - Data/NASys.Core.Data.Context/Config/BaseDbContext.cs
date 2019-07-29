using Microsoft.EntityFrameworkCore;
using NASys.Core.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Context.Config
{
    public class BaseDbContext : DbContext,IDisposable
    {
        public BaseDbContext(DbContextOptions<NASysContext> options): base(options)
        { }
    }
}
