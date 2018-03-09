using Android.App;
using Android.Content;
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
            var tasks = TaskService.LoadTasks();
            _taskListView.Adapter = new TaskListAdapter(tasks);
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
                var intent = new Intent(this, typeof(TaskActivity));
                StartActivity(intent);
            }
            
            return base.OnOptionsItemSelected(item);
        }
    }
}


