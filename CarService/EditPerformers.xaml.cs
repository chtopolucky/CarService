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
    public partial class EditPerformers : Window
    {
        public EditPerformers()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        Исполнители t;
        private void WinJobs_Loaded(object sender, RoutedEventArgs e)
        {
           db.ВидыРаботы.Load();
           //Organization.ItemsSource = db.Исполнители.Local.ToBindingList();
           t = db.Исполнители.Find(Data.Id);
           Id.Text = t.КодИсполнителя.ToString(); 
           Executor.Text = t.ФИО;
        }
        void Save()
        {
            StringBuilder errors = new StringBuilder();
            if (Id.Text.Length == 0) errors.AppendLine("Введите номер по порядку");
            if (Executor.Text.Length == 0) errors.AppendLine("Введите ФИО исполнителя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                
                t.КодИсполнителя = Convert.ToInt32(Id.Text);
                t.ФИО = Executor.Text;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода", "Ошибка");
            }
            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
    }
}
