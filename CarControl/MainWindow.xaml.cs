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
            //List_Auto.ItemsSource = cars;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Auto_Add auto_Add = new Auto_Add();
            auto_Add.Show();
            Hide();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Auto_Search auto_Search = new Auto_Search();
            auto_Search.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Auto_Delete auto_Delete = new Auto_Delete();
            auto_Delete.Show();
        }

    }
}
