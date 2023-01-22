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
            auto_Add.Owner = this;
            auto_Add.Show();
            Hide();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string number_car = Search_Number.Text;
            if (number_car != "")
            {
                List<Car> cars = db.Cars.ToList();
                List<Car> find_Car = new List<Car>();
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Number.Contains(number_car))
                    {
                        find_Car.Add(cars[i]);
                    }
                }
                if(find_Car.Count==0)
                {
                    MessageBox.Show($"Не найдено");
                }
                else
                {
                    autoList.ItemsSource = find_Car;
                }
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
                List<Car> cars = db.Cars.ToList();
                autoList.ItemsSource = cars;
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                //Hide();
            }

        }

        private void autoList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (autoList.SelectedItem != null)
            {
                Car li = (Car)autoList.Items[autoList.SelectedIndex];
            }

        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = db.Cars.ToList();
            List<Car> carsGuest = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if(cars[i].Category == "Гость")
                {
                    carsGuest.Add(cars[i]);
                }
            }
            autoList.ItemsSource = carsGuest;
        }

        private void Constant_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = db.Cars.ToList();
            List<Car> carsConst = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Category == "Постоянная заявка")
                {
                    carsConst.Add(cars[i]);
                }
            }
            autoList.ItemsSource = carsConst;

        }

        private void Temporary_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = db.Cars.ToList();
            List<Car> carsTemp = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Category == "Временная заявка")
                {
                    carsTemp.Add(cars[i]);
                }
            }
            autoList.ItemsSource = carsTemp;

        }

        private void Full_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = db.Cars.ToList();
            autoList.ItemsSource = cars;
        }
    }
}
