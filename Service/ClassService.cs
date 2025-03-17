using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Service
{
    public class ClassService
    {
        ClassRepo _repo;

        public ClassService()
        {
            _repo = new ClassRepo();
        }


        public List<Class> ViewAllClass()
        {
            return _repo.GetAll();
        }
    }
}
