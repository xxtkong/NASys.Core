using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using NASys.Core.Data.Context.Interfaces;

namespace NASys.Core.Data.Context.Config
{
    public class DbConnectionFactory
    {
        private static IDictionary<string, DbConnection> DbConnection;
        private readonly string _connectionString, _connectionWriteString;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionWriteString = configuration.GetConnectionString("DefaultConnectionWrite");
            DbConnection = new Dictionary<string, DbConnection>() {
                    { "read",new SqlConnection(_connectionString)},
                    { "write",new SqlConnection(_connectionWriteString)}
            };
        }
        
        public DbConnection this[string index]
        {
            get
            {
                return DbConnection[index];
            }
        }
        public DbConnection GetFirstConnection
        {
            get
            {
                return DbConnection.Values.First();
            }
        }

    }
}
