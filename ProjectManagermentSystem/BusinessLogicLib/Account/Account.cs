using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels.Object;
using BusinessLogicLib.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace BusinessLogicLib.Account
{
    public class Account
    {

        public static bool IsUserRegistered(string userName)
        {
            List<User> travellers = getUsers();
            foreach (var traveller in travellers)
            {
                if (traveller.username == userName)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsUserValidated(string userName, string password)
        {
            List<User> users = getUsers();

            foreach (var u in users)
            {
                if (u.username == userName && u.password == password)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<User> getUsers()
        {
            ISession session = GetNHibernateSession();
            User userLogin = new User();
            List<User> users = new List<User>();

            users = (from u in session.Query<User>()
                     select u).ToList<User>();
            return users;
        }

        private static ISession GetNHibernateSession()
        {
            NHibernateHelper NHelper = NHibernateHelper.NHelper;
            ISession session = NHelper.GetSession();
            return session;
        }

        public static List<User> GetUsers()
        {
            return getUsers();
        }

        public static void AddNewUser(User newUser)
        {
            ISession session = GetNHibernateSession();
            session.Save(newUser);
        }
    }
}
