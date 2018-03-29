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

        #region Private Methods

        private static void CreateDummyTasks()
        {
            for (var i = 1; i <= 8; i++)
            {
                var task = CreateTask();
                task.IsCompleted = i % 2 == 0;
                task.Title = $"Task {i}";
                task.Description = $"This is the description of task {i}.";

                AddTask(task);
            }
        }

        #endregion
    }
}