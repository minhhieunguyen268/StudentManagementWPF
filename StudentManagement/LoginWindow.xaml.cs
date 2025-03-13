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
using System.Windows.Shapes;
using DataAccess.Models;
using Service;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        AccountService _service;
        public LoginWindow()
        {
            InitializeComponent();
            _service = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            var res = _service.Login(username, password);

            if (res.IsSuccess == true)
            {
                if (res.Value.Role == "student")
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    StudentManagerWindow studentManagerWindow = new StudentManagerWindow(res.Value);
                    this.Close();
                    studentManagerWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Login Error!!", "please try login again!!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void lnkRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.Show();
        }
    }
}
