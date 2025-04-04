using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SBackUp.Views
{
    /// <summary>
    /// Lógica de interacción para TaskView.xaml
    /// </summary>
    public partial class TaskView : Window
    {
        public TaskView()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Solo permite números del 0 al 9
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            // Bloquear siempre el pegado
            e.CancelCommand();
        }
    }
}
