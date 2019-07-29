using Microsoft.AspNetCore.Mvc;
using NASys.Core.UsersApi.Application.Interfaces;
using NASys.Core.UsersApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.UsersApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsersApiService _usersApi;
        public HomeController(IUsersApiService usersApi)
        {
            this._usersApi = usersApi;
        }
        [HttpGet]
        public IEnumerable<UsersViewModel> Get()
        {
            var model = _usersApi.GetAll();
            return model;
        }
        [HttpGet]
        [Route("Find")]
        public UsersViewModel Find(int id)
        {
            var model = _usersApi.GetById(id);
            return model;
        }

        [HttpGet]
        [Route("Add")]
        public int Add()
        {
            return _usersApi.Add(new UsersViewModel() { Mobile = "18623505212" });
        }
        [HttpGet]
        [Route("Add2")]
        public async Task<bool> Add2(string mobile)
        {
            return await _usersApi.Add2(new UsersViewModel() { Mobile = mobile });
        }
        [HttpGet]
        [Route("Add3")]
        public async Task<bool> Add3(string mobile)
        {
            return await _usersApi.Add3(new UsersViewModel() { Mobile = mobile });
        }
    }
}
