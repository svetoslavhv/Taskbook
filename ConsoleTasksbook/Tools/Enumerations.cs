using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTasksbook.Tools
{
    public enum AdministrationManagementEnum
    {
        UserManagement = 1,
        TaskManagement = 2,
        Exit = 3
    }
    public enum UserManagementEnum
    {
        Insert = 1,
        Delete = 2,
        Update = 3,
        Select = 4,
        Exit = 5
    }

    public enum TaskManagementEnum
    {
        Insert = 1,
        Delete = 2,
        UpdateState = 3,
        SelectCreated = 4,
        SelectResponsibleFor = 5,
        GiveHours = 6,
        MakeComment = 7,
        ListComments = 8,
        EditTask = 9,
        Exit = 10
    }
}
