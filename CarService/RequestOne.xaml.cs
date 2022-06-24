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
    /// Логика взаимодействия для RequestOne.xaml
    /// </summary>
    public partial class RequestOne : Window
    {
        public RequestOne()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void WinOneRequest_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridOneRequest.ItemsSource = db.СтоимостьРаботИсполнителей();
        }
    }
}
