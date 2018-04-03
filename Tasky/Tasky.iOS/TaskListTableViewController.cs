using System;
using System.Collections.Generic;
using Foundation;
using Tasky.Shared;
using UIKit;

namespace Tasky.iOS
{
    public partial class TaskListTableViewController : UITableViewController
    {
        private TaskListTableViewSource _tableViewSource;

        public TaskListTableViewController(IntPtr intptr) : base(intptr)
        {
        }

        #region Life Cycle Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Tasks";

            _tableViewSource = new TaskListTableViewSource(TableView);
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);

            _tableViewSource.UpdateTasks();
		}

        #endregion

        #region Navigation

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            TaskDetailsViewController detailsVC;

            switch(segue.Identifier)
            {
                case "ShowTaskSegue":
                    var indexPath = TableView.IndexPathForSelectedRow;
                    var task = _tableViewSource.GetTask(indexPath);

                    detailsVC = segue.DestinationViewController as TaskDetailsViewController;
                    detailsVC.EditedTask = task;
                    TaskService.AssignTask(detailsVC.EditedTask, detailsVC.InputTask);
                    break;

                case "AddTaskSegue":
                    detailsVC = segue.DestinationViewController as TaskDetailsViewController;
                    detailsVC.EditedTask = null;
                    break;
            }
        }

        [Action("UnwindToTaskList:")]
        public void UnwindToTaskList(UIStoryboardSegue segue)
        {
            switch(segue.Identifier)
            {
                case "SaveDetailsSegue":
                    var detailsVC = segue.SourceViewController as TaskDetailsViewController;

                    if (detailsVC.EditedTask == null)
                    {
                        detailsVC.EditedTask = TaskService.CreateTask();
                        TaskService.AddTask(detailsVC.EditedTask);
                    }

                    TaskService.AssignTask(detailsVC.InputTask, detailsVC.EditedTask);
                    break;
            }
        }

        #endregion
    }

    public class TaskListTableViewSource : UITableViewSource
    {
        private const string CellId = "TaskListCell";
        private readonly UITableView _table;
        private List<Task> _tasks;

        public TaskListTableViewSource(UITableView table)
        {
            _table = table;
            _tasks = new List<Task>();

            _table.Source = this;
        }

        #region Overrides

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tasks.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId);

            cell.TextLabel.Text = _tasks[indexPath.Row].Title;

            return cell;        
        }

        #endregion

        #region Public Methods

        public void UpdateTasks()
        {
            _tasks = TaskService.GetTasks();
            _table.ReloadData();
        }

        public Task GetTask(NSIndexPath indexPath)
        {
            return _tasks[indexPath.Row];
        }

        #endregion
    }
}

