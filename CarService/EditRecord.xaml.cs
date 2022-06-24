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
    /// Логика взаимодействия для AddRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = new АвтоСервисEntities();
        Заказы z;
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Id.Text.Length == 0 || double.TryParse(Id.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите номер заказа");
            if(Date.SelectedDate.Value == null) errors.AppendLine("Введите дату");
            if(Client.Text.Length == 0) errors.AppendLine("Укажите клиента");
            if (Executor.Text.Length == 0) errors.AppendLine("Укажите исполнителя");
            if (Mark.Text.Length == 0) errors.AppendLine("Введите марку автомобиля");
            if (Work.Text.Length == 0) errors.AppendLine("Укажите наименование работы");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
           // z = new Заказы();
            z.НомерЗаказа = Convert.ToInt32(Id.Text);
            z.Дата = Date.SelectedDate.Value;
            z.Клиент = db.Клиенты.Where(p => p.ФИО == Client.Text).FirstOrDefault().КодКлиента;
            z.КодРаботы = db.ВидыРаботы.Where(p => p.НаименованиеРаботы == Work.Text).FirstOrDefault().КодРаботы;
            z.КодИсполнителя = db.Исполнители.Where(p => p.ФИО == Executor.Text).FirstOrDefault().КодИсполнителя;
            z.МаркаАвтомобиля = Mark.Text;

            //z = new Заказы();
            //z.НомерЗаказа = Convert.ToInt32(Id.Text);
            try
            {
                    
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Клиенты.Load();
            db.Исполнители.Load();
            db.ВидыРаботы.Load();


            Client.ItemsSource = db.Клиенты.Local.ToBindingList();
            Executor.ItemsSource = db.Исполнители.Local.ToBindingList();
            Work.ItemsSource = db.ВидыРаботы.Local.ToBindingList();


            z = db.Заказы.Find(Data.Id);
            Id.Text = z.НомерЗаказа.ToString();
            Date.SelectedDate = z.Дата;
            Client.Text = z.Клиенты.ФИО;
            Executor.Text = z.Исполнители.ФИО;
            Mark.Text = z.МаркаАвтомобиля;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
