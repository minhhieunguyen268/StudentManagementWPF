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
    /// Interaction logic for StudentDetail.xaml
    /// </summary>
    public partial class StudentDetail : Window
    {

        StudentService _studentService;
        ClassService _classService;
        public StudentDetail(String mssv)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _classService = new ClassService();
            LoadStudentData(mssv);
        }

        private void LoadStudentData(string mssv)
        {
            
            var student = _studentService.GetStudentByMssv(mssv);

            if (student != null)
            {
                // Điền thông tin sinh viên vào các TextBox và ComboBox
                txtMSSV.Text = student.Mssv;
                txtMSSV.IsEnabled = false;
                txtFullName.Text = student.FullName;
                dpDateOfBirth.SelectedDate = student.DateOfBirth.ToDateTime(TimeOnly.MinValue);
                if (student.Gender == "Male")
                {
                    cbGender.SelectedIndex = 0; // Chọn mục "Male"
                }
                else if (student.Gender == "Female")
                {
                    cbGender.SelectedIndex = 1; // Chọn mục "Female"
                }
                txtAddress.Text = student.Address;
                txtPhoneNumber.Text = student.PhoneNumber;
                txtEmail.Text = student.Email;
                txtStudentCode.Text = student.StudentCode;

                
                cbClass.ItemsSource = _classService.ViewAllClass();
                cbClass.SelectedValue = student.ClassId;
            }
            else
            {
                MessageBox.Show("Student not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            StudentManagerWindow studentManagerWindow = new StudentManagerWindow();
            this.Close();
            studentManagerWindow.Show();
        }

        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            string mssv = txtMSSV.Text;
            string fullName = txtFullName.Text;
            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate;
            string gender = (cbGender.SelectedItem as ComboBoxItem)?.Content.ToString();
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            int classId = (int)(cbClass.SelectedValue ?? 0); 
            string studentCode = txtStudentCode.Text;

            
            if (string.IsNullOrWhiteSpace(mssv) || string.IsNullOrWhiteSpace(fullName) || !dateOfBirth.HasValue || string.IsNullOrWhiteSpace(gender) || classId == 0)
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Tạo đối tượng Student từ các giá trị đã nhập
            Student updatedStudent = new Student
            {
                Mssv = mssv,
                FullName = fullName,
                DateOfBirth = DateOnly.FromDateTime(dateOfBirth.Value),
                Gender = gender,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                ClassId = classId,
                StudentCode = studentCode
            };

            // Gọi phương thức UpdateStudent từ Service hoặc tầng dữ liệu
            bool result = _studentService.UpdateStudent(updatedStudent); 

            // Kiểm tra kết quả và thông báo cho người dùng
            if (result)
            {
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadStudentData(mssv);
            }
            else
            {
                MessageBox.Show("Error while updating student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
