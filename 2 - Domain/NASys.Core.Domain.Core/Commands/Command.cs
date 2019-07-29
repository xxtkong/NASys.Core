using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Core.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; set; }
    }
}
