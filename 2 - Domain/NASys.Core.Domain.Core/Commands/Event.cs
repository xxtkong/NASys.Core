using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Core.Commands
{
    public abstract class Event : IRequest<bool>, INotification
    {
        public DateTime Timestamp { get; private set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
