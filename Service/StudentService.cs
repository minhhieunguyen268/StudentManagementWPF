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
    }
}
