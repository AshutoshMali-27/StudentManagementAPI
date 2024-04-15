using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudentManagementAPI.Models;

public partial class Student
{
    public int id { get; set; }

    public string Name { get; set; }

    public string Gender { get; set; }

    public int Age { get; set; }
}

