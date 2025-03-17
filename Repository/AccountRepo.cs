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
    public class AccountRepo
    {
        StudentDbContext _context;

        public AccountRepo()
        {
            _context = new StudentDbContext();
        }

        public Account? GetAccount(string username, string password)
        {
            var finded = _context.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);

            if (finded != null)
            {
                return finded;
            }

            return null;
        }




        public bool AddAccount(Account account)
        {
            var finded = _context.Accounts.FirstOrDefault(a => a.Username == account.Username);

            if (finded != null)
            {
                return false;
            }
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return true;
        }

        public Account GetAccountByStudentId(int studentId)
        {
            return _context.Accounts.FirstOrDefault(a => a.StudentId == studentId);
        }
    }
}
