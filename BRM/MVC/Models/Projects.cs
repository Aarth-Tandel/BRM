using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer;

namespace BRM.Models
{
    public class Projects
    {
        public LogData log { get; set; }
        public List<LogData> logs { get; set; }
        public string Status { get; set; }
    }
}