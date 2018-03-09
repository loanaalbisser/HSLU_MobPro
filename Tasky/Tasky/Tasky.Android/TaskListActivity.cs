using Android.App;
using Android.OS;

namespace Tasky.Droid
{
	[Activity (Label = "Tasky", MainLauncher = true, Icon = "@drawable/icon")]
	public class TaskListActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.TaskListActivity);
		}
	}
}


