using NASys.Core.Data.Context;
using NASys.Core.Data.Repository.Dapper.Common;
using NASys.Core.Domain.Entities;
using NASys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Data.Repository.Repository
{
    public class MessageRepository : DapperRepository<Message>,IMessageRepository
    {
        public MessageRepository(NASysContext dbContext) : base(dbContext.DbConnections)
        {

        }
    }
}
