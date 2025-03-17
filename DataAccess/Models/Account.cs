using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Account
{
    public Account() { }
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? StudentId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public Account(string username, string password, string role, int studentId)
    {

        Username = username;
        Password = password;
        this.Role = role;
        StudentId = studentId;
    }

}
