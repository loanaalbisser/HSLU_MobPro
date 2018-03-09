using Android.App;
using Android.OS;
using Android.Views;

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}


