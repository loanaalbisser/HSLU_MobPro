using System;
using Tasky.Shared;
using Xamarin.Forms.Xaml;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage
    {
        private readonly Task _inputTask;
        
        public TaskPage(Task task)
        {
            InitializeComponent();

            _inputTask = task;
            Task = new Task();
            UpdateTaskFromInput();

            BindingContext = this;
        }

        public Task Task { get; private set; }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (_inputTask == null)
            {
                var newTask = TaskService.CreateTask();
                newTask.Title = Task.Title;
                newTask.Description = Task.Description;
                newTask.IsCompleted = Task.IsCompleted;
                TaskService.AddTask(newTask);
            }
            else
            {
                _inputTask.Title = Task.Title;
                _inputTask.Description = Task.Description;
                _inputTask.IsCompleted = Task.IsCompleted;
            }
            
            Navigation.PopAsync(true);
        }

        private void UpdateTaskFromInput()
        {
            if (_inputTask == null)
                return;

            Task.Title = _inputTask.Title;
            Task.Description = _inputTask.Description;
            Task.IsCompleted = _inputTask.IsCompleted;
        }

    }
}