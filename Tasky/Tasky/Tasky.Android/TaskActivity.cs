using Android.App;
using Android.OS;

namespace Tasky.Droid
{
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.TaskActivity);
        }
    }
}