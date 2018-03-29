using System;
using System.Collections.ObjectModel;
using Tasky.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage
    {
        public TaskListPage()
        {
            InitializeComponent();
            TaskList = new ObservableCollection<Task>();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddTasksFromService();
        }

        private void AddTasksFromService()
        {
            TaskList.Clear();
            foreach (var task in TaskService.GetTasks())
            {
                TaskList.Add(task);
            }
        }

        public ObservableCollection<Task> TaskList { get; }

        private void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
                return;
            var task = (Task)e.SelectedItem;
            TaskListView.SelectedItem = null;
            Navigation.PushAsync(new TaskPage(task));
        }

        private void OnNewTaskCreated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskPage(null));
        }
    }
}