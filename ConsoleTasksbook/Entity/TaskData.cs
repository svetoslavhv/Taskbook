using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Entity
{
    public class TaskData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Time { get; set; }

        public int ResponsibleUser { get; set; }

        public int Creator { get; set; }

        public string CreationDate { get; set; }

        public string LastUpdateDate { get; set; }

        public string State { get; set; }
    }
}
