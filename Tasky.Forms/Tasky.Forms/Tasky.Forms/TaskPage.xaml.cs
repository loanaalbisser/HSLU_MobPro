using System;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using Tasky.Shared;

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
                TaskService.AssignTask(Task, newTask);
                TaskService.AddTask(newTask);
            }
            else
            {
                TaskService.AssignTask(Task, _inputTask);
            }
            
            Navigation.PopAsync(true);
        }

        private void UpdateTaskFromInput()
        {
            if (_inputTask == null)
                return;

            TaskService.AssignTask(_inputTask, Task);
        }

    }
}