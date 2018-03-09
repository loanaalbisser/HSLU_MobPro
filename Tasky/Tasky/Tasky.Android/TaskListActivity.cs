using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Tasky.Droid
{
    [Activity(Label = "Tasky", MainLauncher = true, Icon = "@drawable/icon")]
    public class TaskListActivity : Activity
    {
        private TaskListAdapter _taskListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskListActivity);

            FillListWithTasks();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menu_add)
            {
                var intent = TaskActivity.CreateIntent(this, -1);
                StartActivity(intent);
            }
            
            return base.OnOptionsItemSelected(item);
        }

        private void FillListWithTasks()
        {
            var taskListView = FindViewById<ListView>(Resource.Id.listView_tasks);
            var tasks = TaskService.LoadTasks();
            _taskListAdapter = new TaskListAdapter(tasks);
            taskListView.Adapter = _taskListAdapter;
            taskListView.ItemClick += DoOnItemClicked;
        }

        private void DoOnItemClicked(object sender, AdapterView.ItemClickEventArgs eventArgs)
        {
            var task = _taskListAdapter[eventArgs.Position];
            var intent = TaskActivity.CreateIntent(this, (task.Id));
            StartActivity(intent);
        }
    }
}


