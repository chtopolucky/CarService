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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CarService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = new АвтоСервисEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Заказы.Load();
            DataGrid.ItemsSource = db.ГлавноеОкно();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WinJobs_Click(object sender, RoutedEventArgs e)
        {
            TypesJobs t = new TypesJobs();
            t.ShowDialog();
        }
        
        private void Performers_Click(object sender, RoutedEventArgs e)
        {
            Performers p = new Performers();
            p.ShowDialog();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {

           

            for (int i = 0; i < DataGrid.Items.Count; i++)
            {

                var row = (ГлавноеОкно_Result)DataGrid.Items[i];
                string findContentId = row.НомерЗаказа.ToString();
                string findContentDate = row.Дата.ToString();
                string findContentObject = row.ФИО;
                string findContentOrganization = row.Expr1;
                string findContentAdress = row.Адрес;
                string findContentPhone = row.Телефон;
                string findContentMark = row.МаркаАвтомобиля;
                string findContentJob = row.НаименованиеРаботы;
                string findContentPrice = row.СтоимостьРаботы.ToString();
               if (findContentId != null && findContentId.Contains(find.Text) || 
                   findContentDate != null && findContentDate.Contains(find.Text) || 
                   findContentObject != null && findContentObject.Contains(find.Text)|| 
                   findContentOrganization != null && findContentOrganization.Contains(find.Text) ||
                   findContentAdress != null && findContentAdress.Contains(find.Text) ||
                   findContentPhone != null && findContentPhone.Contains(find.Text) ||
                   findContentMark != null && findContentMark.Contains(find.Text) ||
                   findContentJob != null && findContentJob.Contains(find.Text) ||
                   findContentPrice != null && findContentPrice.Contains(find.Text))
               {
                   object item = DataGrid.Items[i];
                   DataGrid.SelectedItem = item;
                   DataGrid.ScrollIntoView(item);
                   DataGrid.Focus();
                   break;
               }

            }
        }
        //С помощью SQL-запроса вывести сведения о стоимости выполненных работ по исполнителям.ФИО, стоимость выполненных работ.
        private void RequestOne_Click(object sender, RoutedEventArgs e)
        {
            RequestOne ro = new RequestOne();
            ro.ShowDialog();
        }
        //Создать SQL-запрос для вывода сведений о стоимости заказов по каждому клиенту.Запрос должен содержать поля: Клиент, Стоимость заказов.
        private void RequestTwo_Click(object sender, RoutedEventArgs e)
        {
            RequestTwo rt = new RequestTwo();
            rt.ShowDialog();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord ar = new AddRecord();
            ar.ShowDialog();
            DataGrid.ItemsSource = db.ГлавноеОкно();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                ГлавноеОкно_Result row = (ГлавноеОкно_Result)DataGrid.Items[indexRow];
                Data.Id = row.НомерЗаказа;
                EditRecord er = new EditRecord();
                er.ShowDialog();
                DataGrid.Items.Refresh();
                DataGrid.Focus();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ГлавноеОкно_Result record = DataGrid.SelectedItem as ГлавноеОкно_Result;
                    Заказы z = db.Заказы.Where(p => p.НомерЗаказа == record.НомерЗаказа).FirstOrDefault();
                    db.Заказы.Remove(z);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void RequestThree_Click(object sender, RoutedEventArgs e)
        {
            RequestThree rtr = new RequestThree();
            rtr.ShowDialog();
        }

        private void RequestFour_Click(object sender, RoutedEventArgs e)
        {
            RequestFour rf = new RequestFour();
            rf.ShowDialog();
        }

        private void RequestFive_Click(object sender, RoutedEventArgs e)
        {
            RequestFive rf = new RequestFive();
            rf.ShowDialog();
        }

        private void RequestSix_Click(object sender, RoutedEventArgs e)
        {
            RequestSix rs = new RequestSix();
            rs.ShowDialog();
        }
    }
}
