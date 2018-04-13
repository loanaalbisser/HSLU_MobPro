using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.Shared;

namespace Tasky.Droid
{
    [Activity(Label = "Task Details")]
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

        #endregion

        #region Lifecycle Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.TaskActivity);
            RetrieveControls();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        #endregion

        #region Private Methods

        private void RetrieveControls()
        {
            /*_saveButton = FindViewById<Button>(Resource.Id.btn_save);
            _titleInput = FindViewById<EditText>(Resource.Id.edit_title);
            _descriptionInput = FindViewById<EditText>(Resource.Id.edit_description);
            _isCompletedSwitch = FindViewById<Switch>(Resource.Id.switch_isCompleted);*/
        }
        
        #endregion
    }
}