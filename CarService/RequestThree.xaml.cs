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
    /// Логика взаимодействия для RequestThree.xaml
    /// </summary>
    public partial class RequestThree : Window
    {
        public RequestThree()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridThree.ItemsSource = db.Исполнители.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            db.ДобавлениеИсполнителя(Convert.ToInt32(id.Text), fio.Text);
            DataGridThree.ItemsSource = db.Исполнители.ToList();
        }
    }
}
