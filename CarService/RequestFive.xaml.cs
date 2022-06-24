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
    /// Логика взаимодействия для RequestFive.xaml
    /// </summary>
    public partial class RequestFive : Window
    {
        public RequestFive()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();

        private void show(object sender, RoutedEventArgs e)
        {
           DataGridFive.ItemsSource = db.КоличествоЗаказовДень(DateTime.Parse(date.Text));
        }
    }
}
