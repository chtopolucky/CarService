using Base;
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
    /// Логика взаимодействия для AddJobs.xaml
    /// </summary>
    public partial class AddPerformers : Window
    {
        public AddPerformers()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void WinJobs_Loaded(object sender, RoutedEventArgs e)
        {
            db.Исполнители.Load();
            //Organization.ItemsSource = db.Исполнители.Local.ToBindingList();
        }
        Исполнители t;
        void Save()
        {
            if (t==null)
            {
                if (Executor.Text.Length != 0 )
                {
                    t = new Исполнители();
                    t.КодИсполнителя = Convert.ToInt32(Id.Text);
                    t.ФИО = Executor.Text;
                    db.Исполнители.Add(t);
                    db.SaveChanges();
                }
            }
            else
            {
                t.ФИО = Executor.Text;
                db.SaveChanges();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
