using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StudentRepo
    {
        StudentDbContext _context;
        public StudentRepo()
        {
            _context = new StudentDbContext();
        }


        public List<Student> GetAll()
        {
            var listStudent = _context.Students.ToList();
            return listStudent;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }


        public void Update(Student student)
        {
            var finded = _context.Students.FirstOrDefault(x => x.Mssv == student.Mssv);

            if (finded != null)
            {
                finded.FullName = student.FullName;
                finded.DateOfBirth = student.DateOfBirth;
                finded.Gender = student.Gender;
                finded.Address = student.Address;
                finded.PhoneNumber = student.PhoneNumber;
                finded.Email = student.Email;
                finded.ClassId = student.ClassId;
                finded.StudentCode = student.StudentCode;
            }
            else
            {
                throw new Exception("Student not found.");
            }

            _context.SaveChanges();
        }

        public Student GetStudentByMssv(string Mssv)
        {
            return _context.Students.FirstOrDefault(x => x.Mssv == Mssv);
        }

        public bool AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo lỗi
                return false;
            }
        }


        public bool Delete(string mssv)
        {
            var finded = _context.Students.FirstOrDefault(x => x.Mssv == mssv);

            if (finded == null)
            {
                Console.WriteLine($"No student found with ID: {mssv}");
                return false;
            }

            _context.Students.Remove(finded);
            _context.SaveChanges();
            return true;
        }

        

    }
}
