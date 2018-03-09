using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Tasky.Droid
{
    [Activity(Label = "Tasky", MainLauncher = true, Icon = "@drawable/icon")]
    public class TaskListActivity : Activity
    {
        private ListView _taskListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskListActivity);

            _taskListView = FindViewById<ListView>(Resource.Id.listView_tasks);
            var taskService = new TaskService();
            var tasks = taskService.LoadTasks();
            _taskListView.Adapter = new TaskListAdapter(tasks);
}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}


