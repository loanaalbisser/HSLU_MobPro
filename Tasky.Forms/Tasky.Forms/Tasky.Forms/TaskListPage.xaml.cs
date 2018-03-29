using System;
using System.Collections.ObjectModel;
using Tasky.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage
    {
        public TaskListPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        
    }
}