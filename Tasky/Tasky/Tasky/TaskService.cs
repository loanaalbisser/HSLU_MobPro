using System.Collections.Generic;
using System.Linq;

namespace Tasky
{
    public class TaskService
    {
        private readonly List<Task> _taskList;

        public TaskService()
        {
            _taskList = new List<Task>();
            CreateDummyTasks();
        }

        public List<Task> LoadTasks()
        {
            return _taskList;
        }

        public Task CreateTask()
        {
            var newTask = new Task();
            var nextId = _taskList.Select(task => task.Id).DefaultIfEmpty().Max() + 1;

            newTask.Id = nextId;
            return newTask;
        }

        public Task GetTask(int taskId)
        {
            return _taskList.SingleOrDefault(task => task.Id == taskId);
        }

        public void AddTask(Task task)
        {
            _taskList.Add(task);
        }

        #region Private Methods

        public void CreateDummyTasks()
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
                _taskList.Add(task);
            }
        }
        

        #endregion
    }
}