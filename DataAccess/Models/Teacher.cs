using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Msgv { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
