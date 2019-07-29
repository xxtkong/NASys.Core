using NASys.Core.UsersApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.UsersApi.Application.Interfaces
{
    public interface IUsersApiService
    {
        IEnumerable<UsersViewModel> GetAll();
        UsersViewModel GetById(int id);
        int Add(UsersViewModel model);
        Task<bool> Add2(UsersViewModel model);
        Task<bool> Add3(UsersViewModel model);
    }
}
