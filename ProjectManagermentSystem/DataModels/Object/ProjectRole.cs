using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.Object
{
    public class ProjectRole
    {
        public virtual int id { get; set; }
        public virtual string role { get; set; }
        public virtual string userName { get; set; }
        public virtual int projectId { get; set; }
        public virtual string state { get; set; }
    }
}
