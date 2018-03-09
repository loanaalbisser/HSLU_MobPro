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
        private const string TaskIdKey = "TaskId";
        private int _shownTaskId;

        private Button _saveButton;
        private EditText _titleInput;
        private EditText _descriptionInput;
        private Switch _isCompletedSwitch;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.TaskActivity);
            RetrieveControls();

            _shownTaskId = Intent.Extras.GetInt(TaskIdKey);

            _saveButton.Click += DoOnSaveButtonClicked;
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (_shownTaskId != -1)
            {
                var shownTask = TaskService.GetTask(_shownTaskId);
                _titleInput.Text = shownTask.Title;
                _descriptionInput.Text = shownTask.Description;
                _isCompletedSwitch.Checked = shownTask.IsCompleted;
            }
        }

        public static Intent CreateIntent(Context context, int taskId)
        {
            var intent = new Intent(context, typeof(TaskActivity));
            intent.PutExtra(TaskIdKey, taskId);
            return intent;
        }

        private void RetrieveControls()
        {
            _saveButton = FindViewById<Button>(Resource.Id.btn_save);
            _titleInput = FindViewById<EditText>(Resource.Id.edit_title);
            _descriptionInput = FindViewById<EditText>(Resource.Id.edit_description);
            _isCompletedSwitch = FindViewById<Switch>(Resource.Id.switch_isCompleted);
        }

        private void DoOnSaveButtonClicked(object sender, EventArgs e)
        {
            Task task;
            if (_shownTaskId == -1)
                task = TaskService.CreateTask();
            else
                task = TaskService.GetTask(_shownTaskId);

            task.Title = _titleInput.Text;
            task.Description = _descriptionInput.Text;
            task.IsCompleted = _isCompletedSwitch.Checked;

            AddTaskToList(task);

            Finish();
        }

        private void AddTaskToList(Task task)
        {
            if(_shownTaskId == -1)
            TaskService.AddTask(task);
        }
    }
}