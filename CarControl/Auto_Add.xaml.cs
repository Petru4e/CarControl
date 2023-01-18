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
            string number = Number.Text.Replace(" ", "").ToUpper();
            string model = Model.Text;
            string comment = Comment.Text;
            string start_date = Start_Date.Text;
            string end_date = End_Date.Text;
            //Regex regex = new Regex(@"/^[АВЕКМНОРСТУХ]\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\d{2,3}$/ui");
            //MatchCollection matches = regex.Matches(number);

            if (number.Length == 0)
            {
                Number.ToolTip = "Введите номер";
                Number.Background = Brushes.Red;
            }
            else if (Regex.IsMatch(number, @"\p{IsCyrillic}"))
            {
                Number.ToolTip = "Введите номер используя английскую раскладку клавиатуры";
                Number.Background = Brushes.Red;
            }
            else if (model.Length == 0)
            {
                Model.ToolTip = "Введите марку автомобиля";
                Model.Background = Brushes.Red;
            }
            else if (comment.Length == 0)
            {
                Comment.ToolTip = "Введите коментарий: откуда заявка, кто и когда сформировал";
                Comment.Background = Brushes.Red;
            }
            else if (start_date.Length == 0)
            {
                Start_Date.ToolTip = "Введите дату начала действия заявки";
                Start_Date.Background = Brushes.Red;
            }
            else if (end_date.Length == 0)
            {
                End_Date.ToolTip = "Введите дату окончания действия заявки";
                End_Date.Background = Brushes.Red;
            }
            else
            {
                Number.ToolTip = "";
                Number.Background = Brushes.Transparent;
                Model.ToolTip = "";
                Model.Background = Brushes.Transparent;
                Comment.ToolTip = "";
                Comment.Background = Brushes.Transparent;
                Start_Date.ToolTip = "";
                Start_Date.Background = Brushes.Transparent;
                End_Date.ToolTip = "";
                End_Date.Background = Brushes.Transparent;
            }

            if((string)Number.ToolTip == "")
            {
                Car car = new Car(number, model, comment, start_date, end_date);

                db.Cars.Add(car);
                db.SaveChanges();

                MessageBox.Show("Добавлено");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }
            else
            {
                MessageBox.Show($"Исправьте замечания");
            }
            
        }
    }
}
