using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.Object
{
    public class User
    {
        public virtual int id { get; set; }
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual string email { get; set; }
    }
}
