using ConsoleTasksbook.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Repository
{
    public class ComentaryRepository
    {
        private readonly string filePath;

        public ComentaryRepository(string filePath)
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
                    

                    Comentary comentary = new Comentary();
                    comentary.Id = Convert.ToInt32(sr.ReadLine());
                    comentary.TaskId = Convert.ToInt32(sr.ReadLine());
                    comentary.UserId = Convert.ToInt32(sr.ReadLine());
                    comentary.ComentaryText = sr.ReadLine();




                    if (id <= comentary.Id)
                    {
                        id = comentary.Id + 1;
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


        public void Insert(Comentary item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.TaskId);
                sw.WriteLine(item.UserId);
                sw.WriteLine(item.ComentaryText);
               
                
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public List<Comentary> ListAllComments(int TaskId)
        {
            List<Comentary> result = new List<Comentary>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Comentary comentary = new Comentary();
                    comentary.Id = Convert.ToInt32(sr.ReadLine());
                    comentary.TaskId= Convert.ToInt32(sr.ReadLine());
                    comentary.UserId= Convert.ToInt32(sr.ReadLine());
                    comentary.ComentaryText = sr.ReadLine();

                    if (comentary.TaskId == TaskId)
                    {
                        result.Add(comentary);
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
    }
}
