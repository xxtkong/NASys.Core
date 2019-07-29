
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace NASys.Core.Data.IoC
{
    public static class SwaggerConfiguration
    {
        public static void AddConfigure(IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Core Api V2");
                c.RoutePrefix = "swagger";
            });
        }

        public static void AddService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Core Api V1", Version = "v1" });
                c.SwaggerDoc("v2", new Info { Title = "Core Api V2", Version = "v2" });
            });
        }
    }
}
