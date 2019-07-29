using Microsoft.EntityFrameworkCore;
using NASys.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Context
{
    public partial  class NASysContext
    {
        public DbSet<Users> users { get; set; }
    }
}
