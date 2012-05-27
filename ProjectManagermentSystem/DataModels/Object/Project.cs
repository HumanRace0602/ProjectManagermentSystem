using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.Object
{
    public class Project
    {
        public virtual int id { get; set; }
        public virtual string projectName { get; set; }
        public virtual string projectContext { get; set; }
        public virtual DateTime projectPublishTime { get; set; }
        public virtual bool projectState { get; set; }
    }
}
