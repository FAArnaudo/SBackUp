using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SBackUp.ViewModels
{
    public class ControlPanelViewModel : ViewModelBase
    {
        // Fields

        // Properties

        // Commands
        public ICommand CreatTaskCommand { get; }

        // Constructor
        public ControlPanelViewModel()
        {
            CreatTaskCommand = new ViewModelCommand(ExecuteCreateTaskCommand);
        }

        // Methods
        private void ExecuteCreateTaskCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
