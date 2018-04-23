using System;
using Foundation;
using Tasky.Shared;
using UIKit;

namespace Tasky.iOS
{
    public partial class TaskDetailsViewController : UIViewController
    {
        public TaskDetailsViewController(IntPtr intptr) : base(intptr)
        {
            InputTask = new Task();
            EditedTask = null;
        }

        #region Life Cycle Methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TitleLabel.Text = InputTask.Title;
            DescriptionLabel.Text = InputTask.Description;
            CompletedSwitch.On = InputTask.IsCompleted;
        }

        #endregion

        #region Navigation

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            switch (segue.Identifier)
            {
                case "SaveDetailsSegue":
                    InputTask.Title = TitleLabel.Text;
                    InputTask.Description = DescriptionLabel.Text;
                    InputTask.IsCompleted = CompletedSwitch.On;
                    break;
            }
        }

        #endregion

        #region Public Properties

        public Task InputTask { get; set; }

        public Task EditedTask { get; set; }

        #endregion
    }
}
