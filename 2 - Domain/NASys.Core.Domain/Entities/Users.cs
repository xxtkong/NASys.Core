using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Entities
{
    /// <summary>
    /// 实体（注意区分实体与值对象的区别）
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// 实体中的唯一标识,并且是不可变的。更多的时候是Guid类型。。这里为了和数据一样。所以设置为int
        /// </summary>
        public int Id { get; }
        public string Mobile { get; set; }
        public string Pwd { get; set; }
        public string Encrypt { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<decimal> UseBalance { get; set; }

    }
}
