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
    /// Логика взаимодействия для RequestTwo.xaml
    /// </summary>
    public partial class RequestTwo : Window
    {
        public RequestTwo()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void WinTwoRequest_Loaded(object sender, RoutedEventArgs e)
        {
            db.Клиенты.Load();
            DataGridTwoRequest.ItemsSource = db.СтоимостьЗаказовКлиентов();
        }
    }
}
