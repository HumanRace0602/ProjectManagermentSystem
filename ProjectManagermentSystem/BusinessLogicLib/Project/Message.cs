using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLib.Project
{
    public class Message
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
        public string ProjectDescription { get; set; }
        public string Role { get; set; }
    }
}
