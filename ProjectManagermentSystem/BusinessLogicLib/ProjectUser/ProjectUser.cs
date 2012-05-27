using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLib
{
    public class ProjectUser
    {
        public static bool FindExcactUser(string userName)
        {
            return Account.Account.IsUserRegistered(userName);
        }

        public static List<string> FindSimilarUsers(string subUserName)
        {
            List<string> users = new List<string>();

            users = (from u in Account.Account.GetUsers()
                     where u.username.Contains(subUserName)
                     select u.username).ToList();

            return users;
        }
    }
}
