using System.Collections.Generic;
using System.Linq;

namespace Tasky.Shared
{
    public static class TaskService
    {
        private static readonly List<Task> TaskList;

        static TaskService()
        {
            CreateDummyTasks();
        }

        public static List<Task> GetTasks()
        {
            return null;
        }

        public static Task CreateTask()
        {
            return null;
        }

        public static Task GetTask(int taskId)
        {
            return null;
        }

        public static void AddTask(Task task)
        {
            return;
        }

        public static Task AssignTask(Task inputTask, Task outputTask)
        {
            return null;
        }

        #region Private Methods

        private static void CreateDummyTasks()
        {
            
        }

        private static Task CreateNewTask(string title, string description)
        {
            return null;
        }

        #endregion
    }
}