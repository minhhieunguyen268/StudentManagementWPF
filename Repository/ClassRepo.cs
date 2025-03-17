using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace Repository
{
    public class ClassRepo
    {
        StudentDbContext _context;

        public ClassRepo()
        {
            _context = new StudentDbContext();
        }

        public List<Class> GetAll()
        {
            var listClass = _context.Classes.ToList();
            return listClass;
        }

    }
}
