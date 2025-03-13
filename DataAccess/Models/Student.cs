using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Student
{
    public string Mssv { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? ClassId { get; set; }

    public string? StudentCode { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<StudentScore> StudentScores { get; set; } = new List<StudentScore>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
