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
            return TaskList;
        }

        public static Task CreateTask()
        {
            var newTask = new Task();

            var nextId = TaskList.Select(task => task.Id).DefaultIfEmpty().Max() + 1;
            newTask.Id = nextId;

            return newTask;
        }

        public static Task GetTask(int taskId)
        {
            return TaskList.SingleOrDefault(task => task.Id == taskId);
        }

        public static void AddTask(Task task)
        {
            TaskList.Add(task);
        }

        public static Task AssignTask(Task inputTask, Task outputTask)
        {
            outputTask.Title = inputTask.Title;
            outputTask.Description = inputTask.Description;
            outputTask.IsCompleted = inputTask.IsCompleted;

            return outputTask;
        }

        #region Private Methods

        private static void CreateDummyTasks()
        {
            AddTask(CreateNewTask("Chips","Zweifel"));
            AddTask(CreateNewTask("Bier",string.Empty));
            AddTask(CreateNewTask("Nüssli", string.Empty));
            AddTask(CreateNewTask("Cola", string.Empty));
            AddTask(CreateNewTask("Pizza",string.Empty));
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