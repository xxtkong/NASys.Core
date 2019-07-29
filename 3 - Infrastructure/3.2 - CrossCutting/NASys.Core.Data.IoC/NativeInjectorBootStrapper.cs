using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NASys.Core.CrossCutting.Bus;
using NASys.Core.Data.Context;
using NASys.Core.Data.Context.Config;
using NASys.Core.Data.Context.Interfaces;
using NASys.Core.Data.Repository;
using NASys.Core.Data.Repository.Dapper.Common;
using NASys.Core.Data.Repository.Repository;
using NASys.Core.Domain.Commands;
using NASys.Core.Domain.Interfaces.Mediator;
using NASys.Core.Domain.Interfaces.Repository;
using NASys.Core.Domain.Interfaces.Repository.Common;
using NASys.Core.UsersApi.Application.Interfaces;
using NASys.Core.UsersApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NASys.Core.Data.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddNativeInjectorBootStrapper(this IServiceCollection services)
        {
            services.AddUnitOfWork<NASysContext>()
            
            .AddScoped<IMediatorHandler, InMemoryBus>()
            .AddMediatR(typeof(UsersInsertCommand).GetTypeInfo().Assembly)
            
            .AddScoped(typeof(IRepository<>), typeof(DapperRepository<>))
            .AddScoped<DbConnectionFactory>()
            .AddScoped<IUsersApiService, UsersApiService>()
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            //.AddMediatR(typeof(OrdersInsertCommand).GetTypeInfo().Assembly)

            ;
        }
    }
}
