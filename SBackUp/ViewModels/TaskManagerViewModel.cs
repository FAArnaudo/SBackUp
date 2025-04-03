using SBackUp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SBackUp.ViewModels
{
    public class TaskManagerViewModel : ViewModelBase
    {
        // Fields
        private bool isVisible;

        // Properties
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        // Commands
        public ICommand CreatTaskCommand { get; }

        // Constructor
        public TaskManagerViewModel()
        {
            CreatTaskCommand = new ViewModelCommand(ExecuteCreateTaskCommand);
        }

        // Methods
        private void ExecuteCreateTaskCommand(object obj)
        {
            TaskView taskView = new TaskView();

            taskView.Show();
            taskView.Closed += TaskView_Closed;
        }

        private void TaskView_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
