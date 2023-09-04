using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using WpfAppDotNet.Models;

namespace WpfAppDotNet.Views
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectDb.db.Database.EnsureCreated();
            ConnectDb.db.Persons.Load();
            DataContext = ConnectDb.db.Persons.Local.ToObservableCollection();
            PersonsGrid.ItemsSource = ConnectDb.db.Persons.ToList();
        }

        private void Button_Click_AddPerson(object sender, RoutedEventArgs e)
        {
            ConnectDb.db.Persons.Add(new Person
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Birthday = DateTime.Parse(BirthdayTextBox.Text)
            });
            ConnectDb.db.SaveChanges();
            FirstNameTextBox.Text = FirstNameTextBox.Text = BirthdayTextBox.Text = null;
            PersonsGrid.ItemsSource = ConnectDb.db.Persons.ToList();
        }
    }
}
