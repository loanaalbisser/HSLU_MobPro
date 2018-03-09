using System.Collections.Generic;
using System.Linq;

namespace Tasky
{
    public static class TaskService
    {
        static readonly List<Task> TaskList;

        static TaskService()
        {
            TaskList = new List<Task>();
            CreateDummyTasks();
        }

        public static List<Task> LoadTasks()
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
            for (var i = 0; i < 8; i++)
            {
                var task = new Task
                {
                    Id = i,
                    IsCompleted = false,
                    Title = "Task " + i,
                    Description = "This is a description"
                };
                TaskList.Add(task);
            }
        }

        #endregion
    }
}