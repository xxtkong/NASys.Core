using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NASys.Core.UsersApi.Application.ViewModels
{
    public class UsersViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "电话号码必填")]
        [StringLength(11)]
        public string Mobile { get; set; }
    }
}
