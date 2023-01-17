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
using System.Text.RegularExpressions;

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
            string start_date = Start_Date.Text;
            string end_date = End_Date.Text;
            Regex regex = new Regex(@"/^[АВЕКМНОРСТУХ]\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\d{2,3}$/ui");
            MatchCollection matches = regex.Matches(number);
            if (matches.Count > 0)
            {
                Number.ToolTip = "";
                Number.Background = Brushes.Transparent;
              
            }
            else
            {
                Number.ToolTip = "Не корректный номер";
                Number.Background = Brushes.Red;
            }

            
            Car car = new Car(number, model, comment, start_date, end_date);

            db.Cars.Add(car);
            db.SaveChanges();
            
            MessageBox.Show("Добавлено");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
