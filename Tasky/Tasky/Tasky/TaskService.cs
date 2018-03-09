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
    }
}