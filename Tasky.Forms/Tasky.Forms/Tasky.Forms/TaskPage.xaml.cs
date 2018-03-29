using System;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using Tasky.Shared;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage
    {
        private readonly Task _inputTask;
        
        public TaskPage(Task task)
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}