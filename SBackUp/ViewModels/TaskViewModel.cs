using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SBackUp.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        // Fields
        private string taskName = "";
        private string source = "";
        private string destiny = "";
        private string taskPerioricity;
        private string weekly;
        private bool isWeeklyEnable = false;
        private string monthly;
        private bool isMonthlyEnable = false;
        private string hours = "00";
        private string minutes = "00";
        private string seconds = "00";
        private bool isHourEnable = false;

        // Properties
        public ObservableCollection<string> Mode { get; set; }
        public ObservableCollection<string> DaysOfWeek { get; set; }
        public ObservableCollection<string> DaysOfMonth { get; set; }
        public string TaskName
        {
            get => taskName;
            set
            {
                taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }
        public string Destiny
        {
            get => destiny;
            set
            {
                destiny = value;
                OnPropertyChanged(nameof(Destiny));
            }
        }
        public string TaskPerioricity
        {
            get => taskPerioricity;
            set
            {
                taskPerioricity = value.ToString();
                OnPropertyChanged(nameof(TaskPerioricity));
                VerificarHabilitacion();
            }
        }
        public string Hours
        {
            get => hours;
            set
            {
                hours = value;
                OnPropertyChanged(nameof(Hours));
            }
        }
        public string Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                OnPropertyChanged(nameof(Minutes));
            }
        }
        public string Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                OnPropertyChanged(nameof(Seconds));
            }
        }
        public string Weekly
        {
            get => weekly;
            set
            {
                weekly = value;
                OnPropertyChanged(nameof(Weekly));
            }
        }
        public bool IsWeeklyEnable
        {
            get => isWeeklyEnable;
            set
            {
                isWeeklyEnable = value;
                OnPropertyChanged(nameof(IsWeeklyEnable));
            }
        }
        public string Monthly
        {
            get => monthly;
            set
            {
                monthly = value;
                OnPropertyChanged(nameof(Monthly));
            }
        }
        public bool IsMonthlyEnable
        {
            get => isMonthlyEnable;
            set
            {
                isMonthlyEnable = value;
                OnPropertyChanged(nameof(IsMonthlyEnable));
            }
        }
        public bool IsHourEnable
        {
            get => isHourEnable;
            set
            {
                isHourEnable = value;
                OnPropertyChanged(nameof(IsHourEnable));
            }
        }

        // -> Commands
        public ICommand SearchSourceCommand { get; }
        public ICommand SearchDestinyCommand { get; }
        public ICommand CreateCommand { get; }

        // Constructor
        public TaskViewModel()
        {
            Mode = new ObservableCollection<string> { "Manual", "Diario", "Semanal", "Mensual" };

            DaysOfWeek = new ObservableCollection<string> { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };

            DaysOfMonth = new ObservableCollection<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                                             "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
                                                             "20", "21", "22", "23", "24", "25", "26", "27", "28", "29",
                                                             "30", "31" };

            SearchSourceCommand = new ViewModelCommand(ExecuteSearchSourceCommand);
            SearchDestinyCommand = new ViewModelCommand(ExecuteSearchDestinyCommand);
            CreateCommand = new ViewModelCommand(ExecuteCreateCommand, CanExecuteCreateCommand);
        }

        private bool CanExecuteCreateCommand(object obj)
        {
            string regexWindows = @"^[a-zA-Z]:\\(?:[^<>:\""/\\|?*]+\\?)*$";
            bool canExecute = false;
            //

            if (TaskName != "" && Source != "" && Destiny != "")
            {
                if (Regex.IsMatch(Source, regexWindows) && Regex.IsMatch(Destiny, regexWindows))
                {
                    if (TaskPerioricity != null)
                    {
                        canExecute = true;
                    }
                }
            }

            return canExecute;
        }

        private void ExecuteCreateCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteSearchSourceCommand(object obj)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer, // Carpeta raíz (opcional)
                Description = "Selecciona una carpeta" // Descripción del diálogo (opcional)
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                Source = folderPath;
            }
        }

        private void ExecuteSearchDestinyCommand(object obj)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer, // Carpeta raíz (opcional)
                Description = "Selecciona una carpeta" // Descripción del diálogo (opcional)
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                Destiny = folderPath;
            }
        }

        private void VerificarHabilitacion()
        {
            switch (TaskPerioricity)
            {
                case "Manual":
                    IsHourEnable = false;
                    IsWeeklyEnable = false;
                    IsMonthlyEnable = false;
                    break;
                case "Diario":
                    IsHourEnable = true;
                    IsWeeklyEnable = false;
                    IsMonthlyEnable = false;
                    break;
                case "Semanal":
                    IsHourEnable = true;
                    IsWeeklyEnable = true;
                    IsMonthlyEnable = false;
                    break;
                case "Mensual":
                    IsHourEnable = true;
                    IsWeeklyEnable = false;
                    IsMonthlyEnable = true;
                    break;
                default:
                    IsHourEnable = false;
                    IsWeeklyEnable = false;
                    IsMonthlyEnable = false;
                    break;
            }
        }
    }
}
