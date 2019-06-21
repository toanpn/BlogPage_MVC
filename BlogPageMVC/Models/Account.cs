using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace BlogPageMVC.Models
{
    public class Account
    {
        [Display(Name = "Tài Khoản")]
        public string Username { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string PassWord { get; set; }
        public string[] Roles { get; set;  }
    }
}