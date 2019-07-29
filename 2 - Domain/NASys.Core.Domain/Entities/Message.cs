using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public int Uid { get; set; }
        public string UserMobile { get; set; }
    }
}
