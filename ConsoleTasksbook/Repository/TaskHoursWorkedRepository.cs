using ConsoleTasksbook.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Repository
{
    public class TaskHoursWorkedRepository
    {
        private readonly string filePath;

        public TaskHoursWorkedRepository(string filePath)
        {
            this.filePath = filePath;
        }

        private int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    

                    TaskHoursWorked taskHoursWorked = new TaskHoursWorked();
                    taskHoursWorked.Id = Convert.ToInt32(sr.ReadLine());
                    taskHoursWorked.TaskId = Convert.ToInt32(sr.ReadLine());
                    taskHoursWorked.UserId = Convert.ToInt32(sr.ReadLine());
                    taskHoursWorked.WorkedHours = Convert.ToInt32(sr.ReadLine());
                    taskHoursWorked.givingHoursDate = sr.ReadLine();




                    if (id <= taskHoursWorked.Id)
                    {
                        id = taskHoursWorked.Id + 1;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }


        public void Insert(TaskHoursWorked item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.TaskId);
                sw.WriteLine(item.UserId);
                sw.WriteLine(item.WorkedHours);
                sw.WriteLine(item.givingHoursDate);
                
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
    }
}
