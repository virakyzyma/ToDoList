
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks;
        public MainWindow()
        {
            InitializeComponent();
            tasks = new ObservableCollection<Task>();
            taskListView.ItemsSource = tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Откройте окно для добавления задачи и передайте tasks для обновления после добавления задачи
            AddTaskWindow addTaskWindow = new AddTaskWindow(tasks);
            addTaskWindow.ShowDialog();
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            // Изменение статуса задачи
            Button button = (Button)sender;
            Task task = (Task)button.Tag;
            task.Status = (task.Status == "выполнено") ? "не выполнено" : "выполнено";
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Удаление задачи
            Button button = (Button)sender;
            Task task = (Task)button.Tag;
            tasks.Remove(task);
        }

        private void taskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class Task : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public Task(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}