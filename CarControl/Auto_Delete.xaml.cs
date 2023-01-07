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
    /// Логика взаимодействия для Auto_Delete.xaml
    /// </summary>
    public partial class Auto_Delete : Window
    {
        AppContext db;
        public Auto_Delete()
        {
            InitializeComponent();
            db = new AppContext();
        }
        private void Del_Dtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = db.Cars.Find(Convert.ToInt32(DeleteText.Text));
            db.Cars.Remove(car);
            db.SaveChanges();

            MessageBox.Show("Удалено");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
