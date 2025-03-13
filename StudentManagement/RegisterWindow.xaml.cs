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
using Repository;
using Service;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var cfpassword = txtConfirmPassword.Password;

            if (password.Equals(cfpassword) == false)
            {
                MessageBox.Show("Confirm password not same Password!", "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AccountService accountService = new AccountService();
                var check = accountService.Register(new DataAccess.Models.Account(username, password, "student"));
                if (check.IsSuccess == true)
                {
                    LoginWindow loginWindow = new LoginWindow();
                    this.Close();
                    loginWindow.Show();
                }
                else
                {
                    MessageBox.Show(check.Value, "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void lnkLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
