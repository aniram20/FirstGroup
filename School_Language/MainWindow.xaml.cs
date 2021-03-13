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
using System.Data.Entity;

namespace School_Language
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolLanguageEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new SchoolLanguageEntities();
            db.Client.Load();
            dgClients.ItemsSource = db.Client.Local.ToBindingList();

            this.Closing += MainWindow_Closing;     //Вызов метода для очистки кэша при закрытии приложения
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) //Очистка кэша
        {
            db.Dispose();
        }

        public void FirstTen_Click(object sender, RoutedEventArgs e) //Первые 10 записей
        {
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE ID <=10");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "10 из 100";
        }

        private void FirstFifty_Click(object sender, RoutedEventArgs e) //Первые 50 записей
        {
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE ID <=50");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "50 из 100";
        }

        private void FirstTwoH_Click(object sender, RoutedEventArgs e) //Первые 200 записей
        {
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE ID <=200");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "200 из 100";
        }

        private void AllData_Click(object sender, RoutedEventArgs e) //Все записи
        {
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }

        private void RadioButtonM_Checked(object sender, RoutedEventArgs e) //Сортировка мужской пол
        {
            RadioButton pressed = (RadioButton)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE GenderCode = 'м'");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "55 из 100";
        }

        private void RadioButtonF_Checked(object sender, RoutedEventArgs e) //Сортировка женский пол
        {
            RadioButton pressed = (RadioButton)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE GenderCode = 'ж'");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "45 из 100";
        }

        private void RadioButtonA_Checked(object sender, RoutedEventArgs e) //Сортировка все
        {
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }

        private void TextBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE LastName LIKE '%" + textBox.Text + "%'" );
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }

        private void TextBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE FirstName LIKE '%" + textBox.Text + "%'");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }

        private void TextBoxPatronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE Patronymic LIKE '%" + textBox.Text + "%'");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }

        private void TextBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            dgClients.ItemsSource = null;
            db = new SchoolLanguageEntities();
            var clients = db.Database.SqlQuery<Client>("SELECT * FROM Client WHERE Email LIKE '%" + textBox.Text + "%'");
            dgClients.ItemsSource = clients.ToList();
            tbNumber.Text = "100 из 100";
        }
    }
}
