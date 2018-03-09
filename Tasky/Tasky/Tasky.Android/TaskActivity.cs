using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Tasky.Droid
{
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        private Button _saveButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.TaskActivity);

            _saveButton = FindViewById<Button>(Resource.Id.btn_save);
            _saveButton.Click += DoOnSaveButtonClicked;
        }

        private void DoOnSaveButtonClicked(object sender, EventArgs e)
        {
            var titleInput = FindViewById<EditText>(Resource.Id.edit_title);
            var descriptionInput = FindViewById<EditText>(Resource.Id.edit_description);
            var isCompletedSwitch = FindViewById<Switch>(Resource.Id.switch_isCompleted);

            var task = new Task()
            {
                Title = titleInput.Text,
                Description = descriptionInput.Text,
                IsCompleted = isCompletedSwitch.Checked
            };

            TaskService.AddTask(task);

            Finish();
        }
    }
}