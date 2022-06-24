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
    public partial class AddJobs : Window
    {
        public AddJobs()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = АвтоСервисEntities.GetContext();
        private void WinJobs_Loaded(object sender, RoutedEventArgs e)
        {
            db.ВидыРаботы.Load();
            Service.ItemsSource = db.ВидыРаботы.Local.ToBindingList();
        }
        ВидыРаботы t;
        void Save()
        {
            try
            {
                if (t == null)
                {
                    if (Mark.Text.Length != 0 && Service.Text.Length != 0 && Price.Text.Length != 0)
                    {
                        t = new ВидыРаботы();
                        t.КодРаботы = Convert.ToInt32(Id.Text);
                        t.МаркаАвтомобиля = Mark.Text;
                        t.НаименованиеРаботы = Service.Text;
                        t.СтоимостьРаботы = Convert.ToInt32(Price.Text);
                        db.ВидыРаботы.Add(t);
                        db.SaveChanges();
                    }
                }
                else
                {
                    t.МаркаАвтомобиля = Mark.Text;
                    t.НаименованиеРаботы = Service.Text;
                    t.СтоимостьРаботы = Convert.ToInt32(Price.Text);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Введите верные данные");
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
