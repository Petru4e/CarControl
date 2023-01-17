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

namespace CarControl
{
    /// <summary>
    /// Логика взаимодействия для Auto_Find.xaml
    /// </summary>
    public partial class Auto_Find : Window
    {
        AppContext db;
        public Auto_Find(string number_car)
        {
            InitializeComponent();
            db = new AppContext();
            List<Car> cars = db.Cars.ToList();
            List<Car> find_Car = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Number.Contains(number_car))
                {
                    find_Car.Add(cars[i]);
                }
            }
            findAutoList.ItemsSource = find_Car;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
