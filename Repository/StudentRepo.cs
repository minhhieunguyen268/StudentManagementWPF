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
                _context.Entry(finded).CurrentValues.SetValues(student);
            }
            else
            {
                _context.Students.Update(student);
            }

            _context.SaveChanges();
        }


        //public void Delete(int mssv)
        //{
        //    var finded = _context.Students.FirstOrDefault(x => x.Mssv == mssv);

        //    if (finded == null)
        //    {
        //        Console.WriteLine($"no student ID found: {mssv}");
        //        return;
        //    }
        //    _context.Students.Remove(finded);
        //    _context.SaveChanges();
        //}
        //public StudentDTO SearchByStudentID(int mssv)
        //{

        //    var res = _context.Students.FirstOrDefault(s => s.Mssv == mssv);
        //    if (res == null)
        //    {
        //        return new StudentDTO();
        //    }
        //    return TranferModelToDTO.MappedStudentToDTO(res);
        //}


        //public List<StudentDTO> SearchByName(string name)
        //{

        //    List<StudentDTO> listSearch = new List<StudentDTO>();

        //    foreach (var student in GetAll())
        //    {
        //        if (student.Fullname.Contains(name))
        //        {
        //            listSearch.Add(student);
        //        }
        //    }

        //    return listSearch;
        //}
    }
}
