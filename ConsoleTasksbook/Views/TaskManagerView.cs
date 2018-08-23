using ConsoleTasksbook.Entity;
using ConsoleTasksbook.Repository;
using ConsoleTasksbook.Service;
using ConsoleTasksbook.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Views
{
    public class TaskManagerView
    {
        public void Show()
        {
            while (true)
            {
                TaskManagementEnum choice = RenderMenu();
                
                try
                {
                    switch (choice)
                    {
                       
                        case TaskManagementEnum.SelectCreated:
                            {
                                GetAllCreated();
                                break;
                            }

                        case TaskManagementEnum.SelectResponsibleFor:
                            {
                                GetAllResponsibleFor();
                                break;
                            }
                        
                        case TaskManagementEnum.GiveHours:
                            {
                                GiveHoursWorkedOnTask();
                                break;
                            }
                        case TaskManagementEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case TaskManagementEnum.EditTask:
                            {
                                EditTask();
                                break;
                            }
                        case TaskManagementEnum.UpdateState:
                            {
                                UpdateState();
                                break;
                            }
                        case TaskManagementEnum.MakeComment:
                            {
                                MakeComment();
                                break;
                            }
                        case TaskManagementEnum.ListComments:
                            {
                                ListComments();
                                break;
                            }
                        
                        case TaskManagementEnum.Delete:
                            {
                                Delete();
                                break;
                            } 
                        case TaskManagementEnum.Exit:
                            {
                                return;
                            } 
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        private TaskManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tasks management:");
                Console.WriteLine("[C]reated Tasks");
                Console.WriteLine("[R]esponsible for Tasks");
                Console.WriteLine("[E]dit Task");
                Console.WriteLine("[A]dd Task");
                Console.WriteLine("[G]ive worked hours on Task");
                Console.WriteLine("[U]pdate Task State");
                Console.WriteLine("[M]ake comment on Task:");
                Console.WriteLine("[L]ist all comments for task");
                Console.WriteLine("[D]elete Task");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {   
                    
                    case "C":
                        {
                            return TaskManagementEnum.SelectCreated;
                        }

                    case "R":
                        {
                            return TaskManagementEnum.SelectResponsibleFor;
                        }
                        
                    case "G":
                        {
                            return TaskManagementEnum.GiveHours;
                        }
                    
                    case "A":
                        {
                            return TaskManagementEnum.Insert;
                        }
                    case "E":
                        {
                            return TaskManagementEnum.EditTask;
                        }
                    
                    case "U":
                        {
                            return TaskManagementEnum.UpdateState;
                        }
                    case "M":
                        {
                            return TaskManagementEnum.MakeComment;
                        }
                    case "L":
                        {
                            return TaskManagementEnum.ListComments;
                        }
                    
                    case "D":
                        {
                            return TaskManagementEnum.Delete;
                        } 
                    case "X":
                        {
                            return TaskManagementEnum.Exit;
                        }
                     
                     
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAllCreated()
        {
            Console.Clear();

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            List<TaskData> tasks = tasksRepository.GetAllCreated(AuthenticationService.LoggedUser.Id);

            Console.WriteLine("All tasks you created:");

            foreach (TaskData task in tasks)
            {
                Console.WriteLine("Task ID:" + task.Id);
                Console.WriteLine("Title :" + task.Title);
                Console.WriteLine("Description :" + task.Description);
                Console.WriteLine("Responsible User ID: " + task.ResponsibleUser);
                Console.WriteLine("Creator ID:" + task.Creator);
                Console.WriteLine("Creation Date : " + task.CreationDate);
                Console.WriteLine("Last Update Date :" + task.LastUpdateDate);
                Console.WriteLine("State :" + task.State);

                Console.WriteLine("########################################");
            }

            Console.ReadKey(true);
        }

        private void GetAllResponsibleFor()
        {
            Console.Clear();

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            List<TaskData> tasks = tasksRepository.GetAllResponsibleFor(AuthenticationService.LoggedUser.Id);

            Console.WriteLine("All tasks you are responsible for:");

            foreach (TaskData task in tasks)
            {
                Console.WriteLine("Task ID:" + task.Id);
                Console.WriteLine("Title :" + task.Title);
                Console.WriteLine("Description :" + task.Description);
                Console.WriteLine("Responsible User ID: " + task.ResponsibleUser);
                Console.WriteLine("Creator ID:" + task.Creator);
                Console.WriteLine("Creation Date : " + task.CreationDate);
                Console.WriteLine("Last Update Date :" + task.LastUpdateDate);
                Console.WriteLine("State :" + task.State);

                Console.WriteLine("########################################");
            }

            Console.ReadKey(true);
        }

        
        private void Add()
        {
            Console.Clear();

            TaskData taskData = new TaskData();
            taskData.Creator = AuthenticationService.LoggedUser.Id;

            Console.WriteLine("Add new Task:");
            Console.Write("Title: ");
            taskData.Title = Console.ReadLine();
            Console.Write("Description: ");
            taskData.Description = Console.ReadLine();

            Console.Write("Time: ");
            taskData.Time = Convert.ToInt32(Console.ReadLine());

            Console.Write("Responsible User Id: ");
            taskData.ResponsibleUser = Convert.ToInt32(Console.ReadLine());

            Console.Write("Creation Date: ");
            taskData.CreationDate = Console.ReadLine();
            Console.Write("Last Update Date: ");
            taskData.LastUpdateDate = Console.ReadLine();
            Console.Write("State (Waiting or Completed): ");
            taskData.State = Console.ReadLine();


            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            tasksRepository.Save(taskData);

            Console.WriteLine("Task saved successfully.");
            Console.ReadKey(true);

           
        }

        private void EditTask()
        {
            Console.Clear();

            Console.Write("Task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            TaskData task = tasksRepository.GetById(taskId);

            if (task == null)
            {
                Console.Clear();
                Console.WriteLine("Task not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing Task");
            Console.WriteLine("ID:" + task.Id);

            Console.WriteLine("Title:  " + task.Title);
            Console.Write("New Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Description:  " + task.Description);
            Console.Write("New Description :");
            string description = Console.ReadLine();

            Console.WriteLine("Time:  " + task.Time);
            Console.Write("New Time: ");
            int time = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Responsible User ID:  " + task.ResponsibleUser);
            Console.Write("New Responsible User: ");
            int responsibleUser = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Creator ID:  " + task.Creator);
            Console.Write("New Creator: ");
            int creator = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Creation Date:  " + task.CreationDate);
            Console.Write("New Creation Date :");
            string creationDate = Console.ReadLine();

            Console.WriteLine("Last Update Date:  " + task.LastUpdateDate);
            Console.Write("New Last Update Date :");
            string lastUpdateDate = Console.ReadLine();



            if (!string.IsNullOrEmpty(title))
                task.Title = title;
            if (!string.IsNullOrEmpty(description))
                task.Description = description;
            
                task.Time = time;
            
                task.ResponsibleUser = responsibleUser;
            
                task.Creator = creator;
            if (!string.IsNullOrEmpty(creationDate))
                task.CreationDate = creationDate;
            if (!string.IsNullOrEmpty(lastUpdateDate))
                task.LastUpdateDate = lastUpdateDate;

            tasksRepository.Update(task);

            Console.WriteLine("Task updated successfully.");
            Console.ReadKey(true);
        }

        private void GiveHoursWorkedOnTask()
        {
            Console.Clear();

            TaskHoursWorked taskHoursWorked = new TaskHoursWorked();
            taskHoursWorked.UserId = AuthenticationService.LoggedUser.Id;

            Console.WriteLine("Give hours worked on task:");
            
            Console.Write("Task Id: ");
            taskHoursWorked.TaskId = Convert.ToInt32(Console.ReadLine());

            taskHoursWorked.UserId = AuthenticationService.LoggedUser.Id;

            TaskData task = new TaskData();
            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            task = tasksRepository.GetById(taskHoursWorked.TaskId);

            if (task.ResponsibleUser == AuthenticationService.LoggedUser.Id)
            {
                Console.Write("Hours worked: ");
                taskHoursWorked.WorkedHours = Convert.ToInt32(Console.ReadLine());

                Console.Write("Giving Hours Date: ");
                taskHoursWorked.givingHoursDate = Console.ReadLine();

                TaskHoursWorkedRepository taskHoursWorkedRepository = new TaskHoursWorkedRepository("taskHoursWorked.txt");
                taskHoursWorkedRepository.Insert(taskHoursWorked);


                Console.WriteLine("Task hours worked saved successfully.");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("You can only give hours worked on task you are responsible for");
                Console.ReadKey(true);

                
            }
        }

        
        private void UpdateState()
        {
            Console.Clear();

            Console.WriteLine("Update Task State");
            Console.Write("Task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            TaskData task = tasksRepository.GetById(taskId);

            if (task == null)
            {
                Console.Clear();
                Console.WriteLine("Task not found.");
                Console.ReadKey(true);
                return;
            }

            if (task.ResponsibleUser == AuthenticationService.LoggedUser.Id || task.Creator == AuthenticationService.LoggedUser.Id)
            {
                Console.WriteLine("Editing Task State For (" + task.Title + ":   " + task.Description + ")");
                Console.WriteLine("ID:" + task.Id);

                Console.WriteLine("State:  " + task.State);
                Console.Write("New Task State: ");
                string taskState = Console.ReadLine();

                if((task.ResponsibleUser == AuthenticationService.LoggedUser.Id && taskState.ToLower() == "completed")
                        || (task.Creator == AuthenticationService.LoggedUser.Id && taskState.ToLower() == "waiting"))
                {
                    task.State = taskState;
                    tasksRepository.Update(task);
                    Console.WriteLine("Task state updated successfully.");

                    Console.WriteLine("Comentary:");
                    string comentaryText = Console.ReadLine();

                    Comentary comentary = new Comentary();

                    comentary.TaskId = task.Id;
                    comentary.UserId = AuthenticationService.LoggedUser.Id;
                    comentary.ComentaryText = comentaryText;

                    ComentaryRepository comentaryRepository = new ComentaryRepository("comentaries.txt");

                    comentaryRepository.Insert(comentary);
                    Console.WriteLine("Comentary added successfully.");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("You can change the state of a task from \"Completed\" to \"Waiting\" only if you are the creator of the task");
                    Console.WriteLine("You can change the state of a task from \"Waiting\" to \"Completed\" only if you are the responsible for the task");
                    Console.ReadKey(true);
                }

               
            }
            else
            {
                Console.WriteLine("You can only change the state of tasks you are responsible for or you have created");
                Console.ReadKey(true);
            }
            
        }

        private void MakeComment()
        {
            Console.Clear();

            Comentary comentary = new Comentary();
            comentary.UserId = AuthenticationService.LoggedUser.Id;

            Console.WriteLine("Add new Comment on Task:");
            Console.Write("Task ID: ");
            comentary.TaskId = Convert.ToInt32(Console.ReadLine());

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            TaskData taskData = tasksRepository.GetById(comentary.TaskId);

            


            if (taskData.Creator == AuthenticationService.LoggedUser.Id || taskData.ResponsibleUser == AuthenticationService.LoggedUser.Id)
            {
                Console.Write("Commentary: ");
                comentary.ComentaryText = Console.ReadLine();
                ComentaryRepository comentaryRepository = new ComentaryRepository("comentaries.txt");
                comentaryRepository.Insert(comentary);
                Console.WriteLine("Comentary made successfully.");
            }
            else
            {
                Console.WriteLine("You can comment only task you created or you are responsible for.");
            }


            Console.ReadKey(true);
        }

        private void ListComments()
        {
            Console.Clear();

            Console.WriteLine("Get all the commentaries of a task");
            Console.Write("Task ID:");
            int taskId = Convert.ToInt32(Console.ReadLine());

            TasksRepository tasksRespository = new TasksRepository("tasks.txt");
            TaskData task = new TaskData();
            task = tasksRespository.GetById(taskId);

            if (task.Creator == AuthenticationService.LoggedUser.Id || task.ResponsibleUser == AuthenticationService.LoggedUser.Id)
            {
                
                ComentaryRepository comentaryRepository = new ComentaryRepository("comentaries.txt");
                
                List<Comentary> comentaries = comentaryRepository.ListAllComments(task.Id);

                foreach (Comentary comentary in comentaries)
                {
                    Console.WriteLine("Comentary ID:" + comentary.Id);
                    Console.WriteLine("Task ID:  " + comentary.TaskId);
                    Console.WriteLine("Comentator ID:  " + comentary.UserId);
                    Console.WriteLine("Comentary:  " + comentary.ComentaryText);


                    Console.WriteLine("########################################");
                }

                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("You can see only comments on tasks you created or you are responsible for");
                Console.ReadKey(true);
            }
        }
        
        private void Delete()
        {
            
            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
       

            Console.Clear();

            Console.WriteLine("Delete Task:");
            Console.Write("Task Id: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            TaskData task = tasksRepository.GetById(taskId);
            if (task == null)
            {
                Console.WriteLine("Task not found!");
            }
            else
            {
                tasksRepository.Delete(task);
                Console.WriteLine("Task deleted successfully.");
            }
            Console.ReadKey(true);
        }

        
    }
}
