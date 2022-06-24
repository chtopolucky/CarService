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
    public partial class EditJobs : Window
    {
        public EditJobs()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        ВидыРаботы t;
        private void WinJobs_Loaded(object sender, RoutedEventArgs e)
        {
           db.ВидыРаботы.Load();
           Service.ItemsSource = db.ВидыРаботы.Local.ToBindingList();
           t = db.ВидыРаботы.Find(Data.Id);
           Id.Text = t.КодРаботы.ToString(); 
           Mark.Text = t.МаркаАвтомобиля;
           Service.Text = t.НаименованиеРаботы;
           Price.Text = t.СтоимостьРаботы.ToString();
        }
        void Save()
        {
            StringBuilder errors = new StringBuilder();
            if (Id.Text.Length == 0) errors.AppendLine("Введите номер по порядку");
            if (Mark.Text.Length == 0) errors.AppendLine("Введите Марку автомобиля");
            if (Service.Text.Length == 0) errors.AppendLine("Укажите наименование услуги");
            if (Price.Text.Length == 0) errors.AppendLine("Введите стоимость услуги");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                t.КодРаботы = Convert.ToInt32(Id.Text);
                t.КодРаботы = Convert.ToInt32(Id.Text);
                t.МаркаАвтомобиля = Mark.Text;
                t.НаименованиеРаботы = Service.Text;
                t.СтоимостьРаботы = Convert.ToInt32(Price.Text);
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
