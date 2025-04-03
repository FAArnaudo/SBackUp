using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp.Models
{
    public class TaskModel
    {
        // Properties
        public string TaskName { get; set; }
        public string Source { get; set; }
        public string Destiny { get; set; }
        public string TaskPerioricity { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public TaskModel() { }
    }
}
