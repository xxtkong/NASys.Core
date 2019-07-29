using NASys.Core.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.Domain.Interfaces.Mediator
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
