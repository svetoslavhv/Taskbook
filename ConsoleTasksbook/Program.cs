using ConsoleTasksbook.Entity;
using ConsoleTasksbook.Repository;
using ConsoleTasksbook.Service;
using ConsoleTasksbook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LoginView loginView = new LoginView();
            loginView.Show();

            /*if Admin -> AdministrationManagerView*/

            /*if User  -> TasksManagerView*/

            if( AuthenticationService.LoggedUser.Role.ToLower() == "admin" )
            {
                /*FrontPageManagerView*/
                AdministrationManagerView administrationManagerView = new AdministrationManagerView();
                administrationManagerView.Show();

            }else{
                /*FrontPageManagerView*/
                TaskManagerView taskManagerView = new TaskManagerView();
                taskManagerView.Show();
            }

            
            
            
        }
    }
}
