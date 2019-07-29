using DapperExtensions.Mapper;
using NASys.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Mapping
{
    public class MessageMapper : ClassMapper<Message>
    {
        public MessageMapper()
        {
            Table("Message");
            Map(x => x.Id).Column("Id").Key(KeyType.Identity);
            Map(x => x.UserMobile).Ignore();
            AutoMap();
        }
    }
}
