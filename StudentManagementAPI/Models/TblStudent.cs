using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public int? ExamId { get; set; }

    public string? ClassName { get; set; }

    public int? RollNumber { get; set; }
}
