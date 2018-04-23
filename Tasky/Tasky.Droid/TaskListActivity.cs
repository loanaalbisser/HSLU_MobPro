using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Tasky.Shared;

namespace Tasky.Droid
{
    [Activity(Label = "Tasky", MainLauncher = true, Icon = "@drawable/icon")]
    public class TaskListActivity : Activity
    {
        private TaskListAdapter _taskListAdapter;

        #region Lifecycle Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            UpdateTaskList();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menu_add)
            {
                
            }
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            
            return base.OnCreateOptionsMenu(menu);
        }

        #endregion

        #region Private Methods

        private void UpdateTaskList()
        {
            var tasks = TaskService.GetTasks();
            _taskListAdapter.Update(tasks);
        }


        #endregion
    }
}


