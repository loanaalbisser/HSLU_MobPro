using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : INotifyPropertyChanged
    {
        private Task _task;
        
        public TaskPage(Task task)
        {
            InitializeComponent();
            BindingContext = this;
            Task = task;
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        
        public Task Task
        {
            get
            {
                return _task;
            }
            private set
            {
                _task = value;
                RaisePropertyChanged(nameof(Task));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}