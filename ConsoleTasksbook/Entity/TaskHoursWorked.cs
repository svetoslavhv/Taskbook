using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Entity
{
    public class TaskHoursWorked
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int UserId { get; set; }

        public int WorkedHours { get; set; }

        public string givingHoursDate { get; set; }
    }
}
