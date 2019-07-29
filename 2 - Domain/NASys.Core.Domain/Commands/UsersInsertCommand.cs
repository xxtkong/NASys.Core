using NASys.Core.Domain.Core.Commands;
using NASys.Core.Domain.Entities;
using NASys.Core.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Commands
{
    public class UsersInsertCommand : Command
    {
        public Users users { get; set; }
        public string Msg { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new UsersValidation().Validate(this.users);
            return ValidationResult.IsValid;
        }
    }
}
