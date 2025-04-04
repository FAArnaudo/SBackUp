using SBackUp.Models;
using SBackUp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SBackUp.ViewModels
{
    public class TaskManagerViewModel : ViewModelBase
    {
        // Fields
        private bool isViewVisible = true;

        // Properties
        public bool IsViewVisible
        {
            get => isViewVisible;
            set
            {
                isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public TaskView TaskView { get; set; }

        // Commands
        public ICommand CreatTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand ExecuteNowCommand { get; }
        public ICommand DeleteCommand { get; }

        // Constructor
        public TaskManagerViewModel()
        {
            CreatTaskCommand = new ViewModelCommand(ExecuteCreateTaskCommand);
            EditTaskCommand = new ViewModelCommand(ExecuteEditTaskCommand);
            ExecuteNowCommand = new ViewModelCommand(ExecuteExecuteNowCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);

        }

        // Methods
        private void ExecuteCreateTaskCommand(object obj)
        {
            TaskView = new TaskView();
            TaskView.Show();

            IsViewVisible = false;

            TaskView.IsVisibleChanged += TaskView_IsVisibleChanged;
        }

        private void ExecuteDeleteCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteExecuteNowCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteEditTaskCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void TaskView_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            IsViewVisible = true;
        }
    }
}
