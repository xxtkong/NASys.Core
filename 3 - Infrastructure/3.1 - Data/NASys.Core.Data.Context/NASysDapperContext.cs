using Microsoft.Extensions.Configuration;
using NASys.Core.Data.Context.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace NASys.Core.Data.Context
{
    public partial class NASysContext
    {
        public IDbConnection NASysDapperConnection
        {
            get { return new SqlConnection(_connectionString); }
        }
        public DbConnectionFactory DbConnections
        {
            get {
                return new DbConnectionFactory(_configuration) ;
            }
        }
    }
}
