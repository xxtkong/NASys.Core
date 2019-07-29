using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using NASys.Core.Data.Context.Interfaces;
using NASys.Core.Domain.Commands;
using NASys.Core.Domain.Entities;
using NASys.Core.Domain.Interfaces.Repository;
using NASys.Core.Domain.Interfaces.Repository.Common;
using NASys.Core.UsersApi.Application.Interfaces;
using NASys.Core.UsersApi.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.UsersApi.Application.Services
{
    public class UsersApiService :IUsersApiService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IRepository<Users> _repository;
        private readonly IMediator _mediator;
        public UsersApiService(IMapper mapper, IUsersRepository usersRepository, IMediator mediator, IRepository<Users> repository)
        {
            this._mapper = mapper;
            this._usersRepository = usersRepository;
            this._mediator = mediator;
            this._repository = repository;
        }

        /// <summary>
        /// 直接调用仓储新增（几乎不涉及到任何业务逻辑）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(UsersViewModel model)
        {
            ///很多人这里是映射了Command,但本人觉得这造成代码量增加。所以这里直接映射了实体（后果造成代码污染。但这后果我觉得可以忽略不记）
            return _usersRepository.Insert(_mapper.Map<Users>(model));
        }

        /// <summary>
        /// 新增用户。并发送消息到队列，且写入在数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add2(UsersViewModel model)
        {
            return await _mediator.Send<bool>(new UsersInsertCommand()
            {
                Msg = "测试发送消息",
                users = _mapper.Map<Users>(model)
            });
        }

        public IEnumerable<UsersViewModel> GetAll()
        {
            var model = _usersRepository.GetAll();
            return _mapper.Map<IEnumerable<UsersViewModel>>(model);
            //return _usersRepository.GetAll() .ProjectTo<UsersViewModel>(_mapper.ConfigurationProvider); ;
        }

        public async Task<bool> Add3(UsersViewModel model)
        {
            return await _mediator.Send<bool>(new UsersUpdateCommand()
            {
                Msg = "测试发送消息",
                users = _mapper.Map<Users>(model)
            });
        }
        public UsersViewModel GetById(int id)
        {
            //使用通用的repository
            var model = _repository.Find(id);
            //使用当前独有的repository
            //var model2 = _usersRepository.Find(id);
            return _mapper.Map<UsersViewModel>(model);
        }
    }
}
