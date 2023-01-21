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


namespace CarControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();

            List<Car> cars = db.Cars.ToList();
            autoList.ItemsSource = cars;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Auto_Add auto_Add = new Auto_Add();
            auto_Add.Show();
            Hide();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string number_car = Search_Number.Text;
            if (number_car != "")
            {
                Auto_Find auto_find = new Auto_Find(number_car);
                auto_find.Show();
                Hide();
            }
            else MessageBox.Show($"Введите номер");

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (autoList.SelectedItem != null)
            {
                if (autoList.SelectedItem != null)
                {
                    Car li = (Car)autoList.Items[autoList.SelectedIndex];
                    MessageBox.Show($"{li.Number.ToString()} удалено");

                    Car car = db.Cars.Find(li.id);

                    db.Cars.Remove(car);
                    db.SaveChanges();
                }

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }

        }

        private void autoList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (autoList.SelectedItem != null)
            {
                Car li = (Car)autoList.Items[autoList.SelectedIndex];
            }

        }
    }
}
