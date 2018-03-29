using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Shared;

namespace Tasky.Droid
{
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        private const string TaskIdKey = "TaskId";
        private const int NewTaskId = -1;
        private int _shownTaskId;

        private Button _saveButton;
        private EditText _titleInput;
        private EditText _descriptionInput;
        private Switch _isCompletedSwitch;

        #region Public Methods

        public static Intent CreateIntent(Context context, int taskId = NewTaskId)
        {
            var intent = new Intent(context, typeof(TaskActivity));
            intent.PutExtra(TaskIdKey, taskId);
            return intent;
        }

        #endregion


        #region Lifecycle Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.TaskActivity);
            RetrieveControls();

            _shownTaskId = Intent.Extras.GetInt(TaskIdKey);
            _saveButton.Click += DoOnSaveButtonClicked;
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (_shownTaskId == NewTaskId)
                return;

            var shownTask = TaskService.GetTask(_shownTaskId);
            _titleInput.Text = shownTask.Title;
            _descriptionInput.Text = shownTask.Description;
            _isCompletedSwitch.Checked = shownTask.IsCompleted;
        }

        #endregion

        #region Private Methods

        private void RetrieveControls()
        {
            _saveButton = FindViewById<Button>(Resource.Id.btn_save);
            _titleInput = FindViewById<EditText>(Resource.Id.edit_title);
            _descriptionInput = FindViewById<EditText>(Resource.Id.edit_description);
            _isCompletedSwitch = FindViewById<Switch>(Resource.Id.switch_isCompleted);
        }

        private void DoOnSaveButtonClicked(object sender, EventArgs e)
        {
            var task = _shownTaskId == NewTaskId ? TaskService.CreateTask() : TaskService.GetTask(_shownTaskId);

            task.Title = _titleInput.Text;
            task.Description = _descriptionInput.Text;
            task.IsCompleted = _isCompletedSwitch.Checked;

            if (_shownTaskId == NewTaskId)
                TaskService.AddTask(task);

            Finish();
        }

        #endregion
    }
}