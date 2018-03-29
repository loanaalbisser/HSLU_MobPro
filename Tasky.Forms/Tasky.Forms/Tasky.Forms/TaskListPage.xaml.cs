

using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage()
        {
            InitializeComponent();
            var taskList = TaskService.LoadTasks();
            TaskList = new ObservableCollection<Task>(taskList);

            BindingContext = this;
        }

        public ObservableCollection<Task> TaskList { get; set; }

        private void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
                return;
            var task = (Task)e.SelectedItem;
            TaskListView.SelectedItem = null;
            Navigation.PushAsync(new TaskPage(task));
        }
    }
}