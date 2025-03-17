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
        Student selected;
        Account _account;
        public StudentManagerWindow(Account account)
        {
            InitializeComponent();
            _account = account;
            _studentService = new StudentService();
            LoadData();
            txtWelcome.Content = "Hi " + account.Username + "!";
        }

        public StudentManagerWindow()
        {
            InitializeComponent();
            _studentService = new StudentService();
            if (_account != null)
            {
                txtWelcome.Content = "Hi " + _account.Username + "!";
            }
            else
            {
                txtWelcome.Content = "Hi Guest!";
            }
            LoadData();
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
            var temp = dgStudents.SelectedItem as Student;
            if (temp != null)
            {
                selected = temp;
            }else
            {
                selected = null;
            }
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddNewStudent addNewStudent = new AddNewStudent();
            this.Close();
            addNewStudent.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = dgStudents.SelectedItem as Student;

            
            if (selected == null)
            {
                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool check = _studentService.DeleteStudent(selected.Mssv);

            if (check == false)
            {
                MessageBox.Show("Error to Delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoadData();
            }
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {

            var selected = dgStudents.SelectedItem as Student;


            if (selected == null)
            {
                MessageBox.Show("Please select a student to view.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StudentDetail studentDetail = new StudentDetail(selected.Mssv);
            this.Close();
            studentDetail.Show();
        }
    }
}
