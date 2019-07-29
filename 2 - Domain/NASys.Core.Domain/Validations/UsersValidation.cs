using FluentValidation;
using NASys.Core.Domain.Entities;
using NASys.Core.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASys.Core.Domain.Validations
{
    public class UsersValidation: IValidation<Users>
    {
        public UsersValidation()
        {
            RuleFor(o => o.Mobile).NotNull().WithMessage("联系电话必填").Matches(@"^1\d{10}$").WithMessage("请输入正常的电话号码"); ;
        }
    }
}
