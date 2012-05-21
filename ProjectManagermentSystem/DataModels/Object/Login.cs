using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModels.Object
{
    public class Login
    {
        public virtual int id { get; set; }
        public virtual string userName { get; set; }
        public virtual string password { get; set; }
    }
}