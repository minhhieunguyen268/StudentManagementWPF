using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StudentScore
{
    public string Mssv { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public decimal? ExamScore { get; set; }

    public decimal? MidTermScore { get; set; }

    public decimal? FinalScore { get; set; }

    public virtual Student MssvNavigation { get; set; } = null!;
}
