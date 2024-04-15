using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models;

public partial class TblStudentDetail1
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public decimal? TotalMarks { get; set; }

    public decimal? MarkObtained { get; set; }

    public double? Percentage { get; set; }
}
