using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Timetable
{
    public int Id { get; set; }

    public string? Mssv { get; set; }

    public string? Msgv { get; set; }

    public int? ClassId { get; set; }

    public DateOnly? ClassDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Room { get; set; }

    public string? Subject { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Teacher? MsgvNavigation { get; set; }

    public virtual Student? MssvNavigation { get; set; }
}
