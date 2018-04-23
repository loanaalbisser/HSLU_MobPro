using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Tasky.Shared;

namespace Tasky.Droid
{
    public class TaskListAdapter : BaseAdapter<Task>
    {
        private List<Task> _tasks;

        public TaskListAdapter()
        {
            _tasks = new List<Task>();
        }

        public void Update(List<Task> tasks)
        {
            _tasks = tasks;
            NotifyDataSetChanged();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
                var title = view.FindViewById<TextView>(Resource.Id.txt_task_title);
                view.Tag = new ViewHolder {Title = title};
            }
            var holder = (ViewHolder) view.Tag;
            holder.Title.Text = _tasks[position].Title;

            return view;
        }

        public override int Count => _tasks.Count;

        public override Task this[int position] => _tasks[position];
    }

    public class ViewHolder : Java.Lang.Object
    {
        public TextView Title { get; set; }
    }
}