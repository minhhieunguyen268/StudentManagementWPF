using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Service
{
    public class StudentService
    {

        StudentRepo _repo;

        public StudentService()
        {
            _repo = new StudentRepo();
        }
        public List<Student> ViewAllStudent()
        {
            return _repo.GetAll();
        }

        public Student GetStudentByMssv(string mssv)
        {
            if (mssv == null)
            {
                return null;
            }
            return _repo.GetStudentByMssv(mssv.ToUpper());
        }

        public bool AddStudent(Student student)
        {
            return _repo.AddStudent(student);
        }

        public bool DeleteStudent(string mssv)
        {
            bool check = _repo.Delete(mssv);

            if (check)
            {
                return true;
            }

            return false;
        }

        public bool UpdateStudent(Student student)
        {
            if(student == null)
            {
                return false;
            }
            _repo.Update(student);
            return true;
        }
    }
}
