﻿using Android.App;
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
            SetContentView(Resource.Layout.TaskListActivity);
            CreateTaskList();
        }

        protected override void OnResume()
        {
            base.OnResume();
            UpdateTaskList();
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
                var intent = TaskActivity.CreateIntent(this);
                StartActivity(intent);
            }

            return base.OnOptionsItemSelected(item);
        }

        #endregion

        #region Private Methods

        private void CreateTaskList()
        {
            var taskListView = FindViewById<ListView>(Resource.Id.listView_tasks);
            _taskListAdapter = new TaskListAdapter();
            taskListView.Adapter = _taskListAdapter;
            taskListView.ItemClick += DoOnItemClicked;
        }

        private void UpdateTaskList()
        {
            var tasks = TaskService.GetTasks();
            _taskListAdapter.Update(tasks);
        }

        private void DoOnItemClicked(object sender, AdapterView.ItemClickEventArgs eventArgs)
        {
            var task = _taskListAdapter[eventArgs.Position];
            var intent = TaskActivity.CreateIntent(this, task.Id);
            StartActivity(intent);
        }

        #endregion
    }
}


