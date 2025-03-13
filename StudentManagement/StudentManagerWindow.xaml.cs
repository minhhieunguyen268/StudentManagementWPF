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
    /// Interaction logic for StudentManagerWindow.xaml
    /// </summary>
    public partial class StudentManagerWindow : Window
    {
        StudentService _studentService;
        public StudentManagerWindow(Account account)
        {
            InitializeComponent();
            _studentService = new StudentService();
            LoadData();
            txtWelcome.Content = "Hi " + account.Username + "!";
        }
        private void LoadData()
        {
            dgStudents.ItemsSource = null;
            dgStudents.ItemsSource = _studentService.ViewAllStudent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        private void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        }
}
