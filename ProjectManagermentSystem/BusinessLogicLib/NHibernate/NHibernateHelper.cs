using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace BusinessLogicLib.NHibernate
{
    public sealed class NHibernateHelper
    {
        private static NHibernateHelper nHelper = null;
        private ISessionFactory sessionFactory;
        private ISession session;

        private NHibernateHelper()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("DataModels");
            sessionFactory = cfg.BuildSessionFactory();
            session = sessionFactory.OpenSession();
        }

        public static NHibernateHelper NHelper
        {
            get 
            {
                if ( nHelper == null )
                    nHelper = new NHibernateHelper();
                return nHelper;
            } 
        }

        public ISession GetSession()
        {
            return session;
        }
    }
}
