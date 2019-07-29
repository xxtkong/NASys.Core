using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NASys.Core.Data.Context.Config;
using NASys.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Context
{
    public partial class NASysContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public NASysContext(DbContextOptions<NASysContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EnableAutoHistory(null);
        }
        /// <summary>
        /// 配置EFCore 贪婪加载
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}
