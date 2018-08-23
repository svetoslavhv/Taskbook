using ConsoleTasksbook.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Repository
{
    public class TasksRepository
    {
        private readonly string filePath;

        public TasksRepository(string filePath)
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

                    TaskData taskData = new TaskData();
                    taskData.Id = Convert.ToInt32(sr.ReadLine());
                    taskData.Title = sr.ReadLine();
                    taskData.Description = sr.ReadLine();
                    taskData.Time = Convert.ToInt32(sr.ReadLine());
                    taskData.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    taskData.Creator = Convert.ToInt32(sr.ReadLine());
                    taskData.CreationDate = sr.ReadLine();
                    taskData.LastUpdateDate = sr.ReadLine();
                    taskData.State = sr.ReadLine();



                    if (id <= taskData.Id)
                    {
                        id = taskData.Id + 1;
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

        private void Insert(TaskData item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.Title);
                sw.WriteLine(item.Description);
                sw.WriteLine(item.Time);
                sw.WriteLine(item.ResponsibleUser);
                sw.WriteLine(item.Creator);
                sw.WriteLine(item.CreationDate);
                sw.WriteLine(item.LastUpdateDate);
                sw.WriteLine(item.State);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        
        public void Update(TaskData item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TaskData taskData = new TaskData();
                    taskData.Id = Convert.ToInt32(sr.ReadLine());
                    taskData.Title = sr.ReadLine();
                    taskData.Description = sr.ReadLine();
                    taskData.Time = Convert.ToInt32(sr.ReadLine());
                    taskData.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    taskData.Creator = Convert.ToInt32(sr.ReadLine());
                    taskData.CreationDate = sr.ReadLine();
                    taskData.LastUpdateDate = sr.ReadLine();
                    taskData.State = sr.ReadLine();

                    if (taskData.Id != item.Id)
                    {
                        sw.WriteLine(taskData.Id); 
                        sw.WriteLine(taskData.Title);
                        sw.WriteLine(taskData.Description);
                        sw.WriteLine(taskData.Time);
                        sw.WriteLine(taskData.ResponsibleUser);
                        sw.WriteLine(taskData.Creator);
                        sw.WriteLine(taskData.CreationDate);
                        sw.WriteLine(taskData.LastUpdateDate);
                        sw.WriteLine(taskData.State);
                    }
                    else
                    {
                        sw.WriteLine(item.Id);
                        sw.WriteLine(item.Title);
                        sw.WriteLine(item.Description);
                        sw.WriteLine(item.Time);
                        sw.WriteLine(item.ResponsibleUser);
                        sw.WriteLine(item.Creator);
                        sw.WriteLine(item.CreationDate);
                        sw.WriteLine(item.LastUpdateDate);
                        sw.WriteLine(item.State);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public List<TaskData> GetAllCreated(int currentUserId)
        {
            List<TaskData> result = new List<TaskData>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TaskData task = new TaskData();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Title = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Time = Convert.ToInt32(sr.ReadLine());
                    task.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    task.Creator = Convert.ToInt32(sr.ReadLine());
                    task.CreationDate = sr.ReadLine();
                    task.LastUpdateDate = sr.ReadLine();
                    task.State = sr.ReadLine();

                    if (task.Creator == currentUserId)
                    {
                        result.Add(task);
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public List<TaskData> GetAllResponsibleFor(int currentUserId)
        {
            List<TaskData> result = new List<TaskData>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TaskData task = new TaskData();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Title = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Time = Convert.ToInt32(sr.ReadLine());
                    task.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    task.Creator = Convert.ToInt32(sr.ReadLine());
                    task.CreationDate = sr.ReadLine();
                    task.LastUpdateDate = sr.ReadLine();
                    task.State = sr.ReadLine();

                    if (task.ResponsibleUser == currentUserId)
                    {
                        result.Add(task);
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }
        
        public TaskData GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TaskData task = new TaskData();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Title = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Time = Convert.ToInt32(sr.ReadLine());
                    task.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    task.Creator = Convert.ToInt32(sr.ReadLine());
                    task.CreationDate = sr.ReadLine();
                    task.LastUpdateDate = sr.ReadLine();
                    task.State = sr.ReadLine();

                    if (task.Id == id)
                    {
                        return task;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        
        
        public void Delete(TaskData item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TaskData task = new TaskData();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Title = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Time = Convert.ToInt32(sr.ReadLine());
                    task.ResponsibleUser = Convert.ToInt32(sr.ReadLine());
                    task.Creator = Convert.ToInt32(sr.ReadLine());
                    task.CreationDate = sr.ReadLine();
                    task.LastUpdateDate = sr.ReadLine();
                    task.State = sr.ReadLine();

                    if (task.Id != item.Id)
                    {
                        sw.WriteLine(task.Id);
                        sw.WriteLine(task.Title);
                        sw.WriteLine(task.Description);
                        sw.WriteLine(task.Time);
                        sw.WriteLine(task.ResponsibleUser);
                        sw.WriteLine(task.Creator);
                        sw.WriteLine(task.CreationDate);
                        sw.WriteLine(task.LastUpdateDate);
                        sw.WriteLine(task.State);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
        
        public void Save(TaskData item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }
        /*
        public User GetByUsernameAndPassword(string username, string password)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();
                    user.Role = sr.ReadLine();

                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }
        
        */
    }
}
