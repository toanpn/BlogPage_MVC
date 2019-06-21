using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPageMVC.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();

        public AccountModel()
        {
            listAccounts.Add(new Account { Username = "admin", PassWord = "admin", Roles = new string[] { "admin", "viewer" } });
            listAccounts.Add(new Account { Username = "toanpn", PassWord = "123", Roles = new string[] { "admin", "viewer" } });
        }

        public Account AccountFind(string userName)
        {
            return listAccounts.Single(acc => acc.Username.Equals(userName));
        }

        public Account Login(string userName, string passWord)
        {
            return listAccounts.Where(acc => acc.Username.Equals(userName) && acc.PassWord.Equals(passWord)).FirstOrDefault();
        }
    }
}