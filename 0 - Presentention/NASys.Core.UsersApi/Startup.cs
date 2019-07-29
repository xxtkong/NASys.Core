using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NASys.Core.Data.Context;
using NASys.Core.Data.IoC;
using NASys.Core.UsersApi.Application.Controllers;
using NASys.Core.UsersApi.Application.Extensions;

namespace NASys.Core.UsersApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerConfiguration.AddService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddApplicationPart(typeof(ValuesController).Assembly);
            //内存数据库
            //ConfigureInMemoryDatabases(services);
            //正式库

            ConfigureProductionServices(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapperSetup();
            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //添加缓存
            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddNativeInjectorBootStrapper();
        }

        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<NASysContext>(c => c.UseInMemoryDatabase("Default"));
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
           
            services.AddDbContext<NASysContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            SwaggerConfiguration.AddConfigure(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
