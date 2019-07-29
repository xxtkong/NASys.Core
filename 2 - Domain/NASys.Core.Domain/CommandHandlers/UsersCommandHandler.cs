using MediatR;
using NASys.Core.Domain.Commands;
using NASys.Core.Domain.Interfaces.Mediator;
using NASys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace NASys.Core.Domain.CommandHandlers
{
    public class UsersCommandHandler : CommonHandler, IRequestHandler<UsersInsertCommand, bool>,IRequestHandler<UsersUpdateCommand,bool>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMediatorHandler _bus;
        public UsersCommandHandler(IUsersRepository usersRepository, IMessageRepository messageRepository, IMediatorHandler bus) :base(bus)
        {
            this._usersRepository = usersRepository;
            this._messageRepository = messageRepository;
            this._bus = bus;
        }
        /// <summary>
        /// 这里的逻辑 我新增一位用户，并发送一条消息到消息队列，且写入消息表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(UsersInsertCommand request, CancellationToken cancellationToken)
        {
            #region 单链接事务
            //首先验证输入用户信息是否正确
            if (request.IsValid())
            {
                //单链接事务
                try
                {
                    using (var connection = _usersRepository.GetFirstConnection())
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                            connection.Open();
                        //开启事务
                        var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                        _usersRepository.Find(1,transaction);
                        //请注意。这里很多人的做法是通过实例化实体在赋予值的方式，比如：new Users(){Mobile='' ,Id = }
                        //在应用层使用对象映射到Command，本人实在是觉得没多大用，并且增加了代码量。。。所以在应用层映射了值对象（可能是理解不够深刻） 

                        int userId = _usersRepository.Insert(request.users, transaction);
                        //写入消息表(注：这里可以写SQL语句。也可以写Repository。实例中为了演示Mapping，用的也可以写Repository)
                        _messageRepository.Insert(new Entities.Message() { Msg = request.Msg, Uid = userId }, transaction);
                        transaction.Commit();
                        //发送消息队列
                        return Task.FromResult(true);
                    }
                }
                catch (Exception ex)
                {
                    //写入错误日志
                    throw;
                }
            }
            else
            {
                //验证不通过
                NotifyValidationErrors(request);
            }
            return Task.FromResult(false);
            #endregion
        }

        /// <summary>
        /// 同上逻辑。这里是分布式事务
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> Handle(UsersUpdateCommand request, CancellationToken cancellationToken)
        {
            #region 分布式事务
            //首先验证输入用户信息是否正确
            if (request.IsValid())
            {
                ///分布式隐式事务
                using (TransactionScope ts = new TransactionScope())
                {
                    _usersRepository.Find(1);
                    int userId = _usersRepository.Insert(request.users);
                    _messageRepository.Insert(new Entities.Message() { Msg = request.Msg, Uid = userId });
                    ts.Complete();
                }

                //分布式显示事务（这个没调通）
                //using (var transaction = new CommittableTransaction())
                //{
                //    try
                //    {
                //        _usersRepository.Find(1, transaction);
                //        int userId = _usersRepository.Insert(request.users, transaction);
                //        //写入消息表(注：这里可以写SQL语句。也可以写Repository。实例中为了演示Mapping，用的也可以写Repository)
                //        _messageRepository.Insert(new Entities.Message() { Msg = request.Msg, Uid = userId }, transaction);
                //        transaction.Commit();
                //        //发送消息队列
                //        return Task.FromResult(true);
                //    }
                //    catch (Exception ex)
                //    {

                //        throw;
                //    }
                //}

                return Task.FromResult(true);
            }
            else
            {
                //验证不通过
                NotifyValidationErrors(request);
            }
            return Task.FromResult(false);
            #endregion
        }
    }
}
