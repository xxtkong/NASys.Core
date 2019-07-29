using AutoMapper;
using NASys.Core.Domain.Entities;
using NASys.Core.UsersApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASys.Core.UsersApi.Application
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsersViewModel, Users>();
        }
    }
}
