using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        private ObservableCollection<Task> tasks;
        public AddTaskWindow(ObservableCollection<Task> tasksList)
        {
            InitializeComponent();
            tasks = tasksList;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = taskNameTextBox.Text;
            string status = ((ComboBoxItem)taskStatusComboBox.SelectedItem).Content.ToString();
            tasks.Add(new Task(name, status));
        }
    }
}
