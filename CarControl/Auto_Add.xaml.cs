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
    /// Логика взаимодействия для Auto_Add.xaml
    /// </summary>
    public partial class Auto_Add : Window
    {
        AppContext db;
        public Auto_Add()
        {
            InitializeComponent();
            db = new AppContext();
        }
        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            string number = Number.Text.Trim().ToLower();
            string model = Model.Text.Trim().ToLower();
            string comment = Comment.Text;
            string date_start = Date_Start.Text;
            string date_end = Date_End.Text;
            if (number.Length < 3)
            {
                Number.ToolTip = "Не корректный номер";
                Number.Background = Brushes.Red;
            }
            else
            {
                Number.ToolTip = "";
                Number.Background = Brushes.Transparent;
            }

            //MainWindow mainWindow = new MainWindow();
            Car car = new Car(number, model, comment, date_start, date_end);

            db.Cars.Add(car);
            db.SaveChanges();
            
            MessageBox.Show("Добавлено");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
