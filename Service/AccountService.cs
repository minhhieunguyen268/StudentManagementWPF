using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using Repository;

namespace Service
{
    public class AccountService
    {
        AccountRepo _repo;

        public AccountService()
        {
            _repo = new();
        }

        public Response<Account> Login(string username, string password)
        {

            Response<Account> response = new Response<Account>();


            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                response.IsSuccess = false;
            }
            else
            {
                var account = _repo.GetAccount(username, password);
                if (account != null)
                {
                    response.Value = account;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            return response;

        }

        public Response<String> Register(Account account)
        {
            Response<String> response = new Response<String>();

            if (account.Username.Length < 8 || account.Password.Length < 8)
            {
                response.Value = "Username And Password must greater than 8 characters";
                response.IsSuccess = false;
            }
            else if (_repo.AddAccount(account) == false)
            {
                response.Value = "Username already exists in the system";
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
            }
            return response;
        }

        public Account GetAccountByStudentId(int StudentId)
        {
            return _repo.GetAccountByStudentId(StudentId);
        }

    }
}
