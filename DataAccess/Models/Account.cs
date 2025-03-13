using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public Account(string username, string password, string Role)
    {

        Username = username;
        Password = password;
        this.Role = Role;

    }
}
