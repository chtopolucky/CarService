using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace CarService
{
    /// <summary>
    /// Логика взаимодействия для RequestFour.xaml
    /// </summary>
    public partial class RequestFour : Window
    {
        public RequestFour()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Исполнители.Load();
            DataGridFour.ItemsSource = db.КоличествоЗаказовАвтомобилей();
        }
    }
}
