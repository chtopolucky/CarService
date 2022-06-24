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
    /// Логика взаимодействия для WindowPerformers.xaml
    /// </summary>
    public partial class WindowPerformers : Window
    {
        public WindowPerformers()
        {
            InitializeComponent();
        }
        РаботаEntities db = new РаботаEntities();
        private void WinPerformers_Loaded(object sender, RoutedEventArgs e)
        {
            db.Исполнители.Load();
            DataGridPerformers.ItemsSource = db.Исполнители.ToList();
        }
    }
}
