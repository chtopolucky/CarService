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
    /// Логика взаимодействия для TypesJobs.xaml
    /// </summary>
    public partial class Performers : Window
    {
        public Performers()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = new АвтоСервисEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Исполнители.Load();
            DataGridPerformers.ItemsSource = db.Исполнители.ToList();
        }
        Исполнители p1;
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result==MessageBoxResult.Yes)
            {
                try
                {
                    Исполнители row = (Исполнители)DataGridPerformers.SelectedItems[0];
                    db.Исполнители.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPerformers aj = new AddPerformers();
            aj.ShowDialog();
            DataGridPerformers.Items.Refresh();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            db = new АвтоСервисEntities();
            db.Исполнители.Load();
            DataGridPerformers.ItemsSource = db.Исполнители.Local.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indexRow = DataGridPerformers.SelectedIndex;
                if (indexRow != -1)
                {
                    Исполнители row = (Исполнители)DataGridPerformers.Items[indexRow];
                    Data.Id = row.КодИсполнителя;
                    EditPerformers ej = new EditPerformers();
                    ej.ShowDialog();
                    DataGridPerformers.Items.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Выберите строку для изменения");
            }
        }

        private void DataGridPerformers_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            p1 = (Исполнители)DataGridPerformers.CurrentCell.Item;
        }

        private void DataGridPerformers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (p1 == null)
            {
                p1 = new Исполнители();
                p1.ФИО = ((TextBox)(e.EditingElement)).Text;
                db.Исполнители.Add(p1);
                db.SaveChanges();
            }
            else
            {
                p1.ФИО = ((TextBox)(e.EditingElement)).Text;
                db.SaveChanges();
            }
        }
    }
}
