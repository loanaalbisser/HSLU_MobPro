using System.Collections.Generic;
using System.Linq;

namespace Tasky.Shared
{
    public static class TaskService
    {
        private static readonly List<Task> TaskList;

        static TaskService()
        {
            TaskList = new List<Task>();
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
            AddTask(CreateNewTask("Chips", "Zweifel"));
            AddTask(CreateNewTask("Bier", string.Empty));
            AddTask(CreateNewTask("Nüssli", string.Empty));
            AddTask(CreateNewTask("Cola", string.Empty));
            AddTask(CreateNewTask("Pizza", string.Empty));
            AddTask(CreateNewTask("Oreos", string.Empty));

        }

        private static Task CreateNewTask(string title, string description)
        {
            var task = CreateTask();
            task.Title = title;
            task.Description = description;

            return task;

        }

        #endregion
    }
}