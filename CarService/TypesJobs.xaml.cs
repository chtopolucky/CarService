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
    public partial class TypesJobs : Window
    {
        public TypesJobs()
        {
            InitializeComponent();
        }
        АвтоСервисEntities db = new АвтоСервисEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.ВидыРаботы.Load();
            DataGridJobs.ItemsSource = db.ВидыРаботы.ToList();
        }
        ВидыРаботы p1;
        private void DataGridJobs_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            p1 = (ВидыРаботы)DataGridJobs.CurrentCell.Item;
        }

        private void DataGridJobs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(p1==null)
            {
                p1 = new ВидыРаботы();
                p1.НаименованиеРаботы = ((TextBox)(e.EditingElement)).Text;
                db.ВидыРаботы.Add(p1);
                db.SaveChanges();
            }
            else
            {
                p1.НаименованиеРаботы = ((TextBox)(e.EditingElement)).Text;
                db.SaveChanges();
            }
        }

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
                    ВидыРаботы row = (ВидыРаботы)DataGridJobs.SelectedItems[0];
                    db.ВидыРаботы.Remove(row);
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
            AddJobs aj = new AddJobs();
            aj.ShowDialog();
            DataGridJobs.Items.Refresh();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            db = new АвтоСервисEntities();
            db.ВидыРаботы.Load();
            DataGridJobs.ItemsSource = db.ВидыРаботы.Local.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGridJobs.SelectedIndex;
            if (indexRow != -1)
            {
                ВидыРаботы row = (ВидыРаботы)DataGridJobs.Items[indexRow];
                Data.Id = row.КодРаботы;
                EditJobs ej = new EditJobs();
                ej.ShowDialog();
                DataGridJobs.Items.Refresh();
            }
        }
    }
}
