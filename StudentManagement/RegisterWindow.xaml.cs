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
            var mssv = txtMSSV.Text;
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var cfpassword = txtConfirmPassword.Password;

            if(string.IsNullOrEmpty(mssv))
            {
                MessageBox.Show("Enter mssv to register", "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (password.Equals(cfpassword) == false)
            {
                MessageBox.Show("Confirm password not same Password!", "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                StudentService _studentService = new StudentService();
                AccountService _accountService = new AccountService();
                var student = _studentService.GetStudentByMssv(mssv);



                if (student == null)
                {
                    MessageBox.Show("Student does not exist in the system!", "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var existingAccount = _accountService.GetAccountByStudentId(student.StudentId);
                    if (existingAccount != null)
                    {
                        MessageBox.Show("Student already has an account!", "Error to Register", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        var check = _accountService.Register(new DataAccess.Models.Account(username, password, "student", student.StudentId));
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
