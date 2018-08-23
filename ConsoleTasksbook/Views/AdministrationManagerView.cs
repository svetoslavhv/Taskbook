using ConsoleTasksbook.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Views
{
    public class AdministrationManagerView
    {
        public void Show()
        {
            while (true)
            {
                AdministrationManagementEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {

                        case AdministrationManagementEnum.UserManagement:
                            {
                                UserManagerView userManagerView = new UserManagerView();
                                userManagerView.Show();
                                break;
                            }
                        case AdministrationManagementEnum.TaskManagement:
                            {
                                
                                 TaskManagerView taskManagerView = new TaskManagerView();
                                 taskManagerView.Show();
                                 
                                
                                break;
                            }

                        case AdministrationManagementEnum.Exit:
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

        private AdministrationManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Administration management:");
                Console.WriteLine("[U]sers management");
                Console.WriteLine("[T]asks management");
                Console.WriteLine("E[x]it");
                

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "U":
                        {
                            return AdministrationManagementEnum.UserManagement;
                        }
                    case "T":
                        {
                            return AdministrationManagementEnum.TaskManagement;
                        }
                    case "X":
                        {
                            return AdministrationManagementEnum.Exit;
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
    }
}
