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
    /// Interaction logic for AddNewStudent.xaml
    /// </summary>
    public partial class AddNewStudent : Window
    {
        StudentService _studentService;
        ClassService _classService;
        public AddNewStudent()
        {
            _studentService = new StudentService();
            _classService = new ClassService();
            InitializeComponent();
            LoadNameClass();
        }

        public void LoadNameClass()
        {
            var classes = _classService.ViewAllClass();
            cbClass.ItemsSource = classes;
        }

       private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Invalid Student ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter the full name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (dpDateOfBirth.SelectedDate == null)
            {
                MessageBox.Show("Please select a valid date of birth", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select Gender", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter the address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter the phone number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter the email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (cbClass.SelectedItem == null)
            {
                MessageBox.Show("Please select a class", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtStudentCode.Text))
            {
                MessageBox.Show("Please enter the Student Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            var existingStudent = _studentService.GetStudentByMssv(txtMSSV.Text);  

            if (existingStudent != null) 
            {
                MessageBox.Show("Student with this MSSV already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Student student = new Student();
            student.Mssv = txtMSSV.Text;
            student.FullName = txtFullName.Text;
            student.DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value);
            student.Gender = cbGender.SelectedItem != null ? ((ComboBoxItem)cbGender.SelectedItem).Content.ToString() : "Male"; // Giới tính, mặc định là Male
            student.Address = txtAddress.Text;
            student.PhoneNumber = txtPhoneNumber.Text;
            student.Email = txtEmail.Text;
            student.ClassId = ((Class)cbClass.SelectedItem).Id;
            student.StudentCode = txtStudentCode.Text;


            var result = _studentService.AddStudent(student);

            if (result)
            {
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                StudentManagerWindow studentManagerWindow = new StudentManagerWindow();
                this.Close();
                studentManagerWindow.Show();
            }
            else
            {
                MessageBox.Show("Error while adding student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            StudentManagerWindow studentManagerWindow = new StudentManagerWindow();
            this.Close();
            studentManagerWindow.Show();
        }
    }
}
