using List_24._06.src;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace List_24._06
{
    public partial class MainWindow : Window
    {
        public List<ToDo> toDoList = new List<ToDo>();
        public MainWindow()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Today.AddDays(1);

            toDoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 01, 15), "Нет описания"));
            toDoList.Add(new ToDo("Поработать", new DateTime(2024, 01, 20), "Съездить на совещание в Москву"));
            toDoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 02, 01), "Съездить в отпуск в Сочи"));
            RefreshToDoList();
            CheckboxEnableToDo_Unchecked(Owner, new RoutedEventArgs()); // скрывает правую панель
        }

        private void RefreshToDoList()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = toDoList;
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (groupBoxToDo == null || buttonAdd == null) return;
            groupBoxToDo.Visibility = Visibility.Visible;
            buttonAdd.Visibility = Visibility.Visible;
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (groupBoxToDo == null || buttonAdd == null) return;
            groupBoxToDo.Visibility = Visibility.Hidden;
            buttonAdd.Visibility = Visibility.Hidden;
        }

        private void ButtonRemoveToDo_Click(object sender, RoutedEventArgs e)
        {
            toDoList.Remove(listToDo.SelectedItem as ToDo);
            RefreshToDoList();
        }
        private void ButtonAddToDo_Click(object sender, RoutedEventArgs e)
        {
            if (!dateToDo.SelectedDate.HasValue)
            {
                MessageBox.Show("Даты нет", Name = "error");
                return;
            }
            toDoList.Add(new ToDo(titleToDo.Text, (DateTime)dateToDo.SelectedDate, descriptionToDo.Text));
            titleToDo.Text = null;
            descriptionToDo.Text = "Описания нет";
            RefreshToDoList();
        }
    }
}
