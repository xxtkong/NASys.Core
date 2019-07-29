using NASys.Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Entities.OrderAggregate
{
    public class Order : AggregateRoot
    {
        /// <summary>
        /// 订单号,虽然唯一。。但有意义。不建议作为唯一标识
        /// </summary>
        public string OrderNo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Address ShipToAddress { get; private set; }
    }
}
