using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentManagementAPI.Models;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public StudentAPIController(IConfiguration config)
        {

            _configuration = config;

            string cs = _configuration.GetConnectionString("dbcs");

        }



        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<ActionResult<List<Student>>> getAllStudents()
        {
            List<Student> studentlist = new List<Student>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbcs")))
            {
                SqlCommand cmd = new SqlCommand("Sp_StudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student obj = new Student();
                    obj.id = Convert.ToInt32(reader["id"]);
                    obj.Name = reader["Name"].ToString() ?? "";
                    obj.Gender = reader["Gender"].ToString() ?? "";
                    obj.Age = Convert.ToInt32(reader["Age"]);
                    studentlist.Add(obj);
                }
            }
            // return studentlist;

            var data = studentlist;
            return Ok(data);
        }




        [HttpPost]
        [Route("SetAllStudent")]
        public bool AddStudents(Student std)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbcs"));
            SqlCommand cmd = new SqlCommand("Sp_SETStudentDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Age", std.Age);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        [HttpGet]
        [Route("getAllStudentsBYID/{id}")]
        public async Task<ActionResult<Student>> getAllStudentsBYID(int id)
        {
            Student studentByID = null;


            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbcs")))
            {
                SqlCommand cmd = new SqlCommand("Sp_StudentDetailsByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If a record is found
                {
                    studentByID = new Student(); // Initialize studentByID
                    studentByID.id = Convert.ToInt32(reader["id"]);
                    studentByID.Name = reader["Name"].ToString() ?? "";
                    studentByID.Gender = reader["Gender"].ToString() ?? "";
                    studentByID.Age = Convert.ToInt32(reader["Age"]);
                }
            }

            var data = studentByID;
            return Ok(data);
          






        }



        [HttpPut]
        [Route("updateStudentsByID/{id}")]
        public bool updateStudentsByID(Student std)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbcs"));
            SqlCommand cmd = new SqlCommand("SP_UpdateStudents", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", std.id);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Age", std.Age);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("DeleteStudentsByID/{id}")]
        public bool DeletestudentDetail(int id)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("dbcs"));
            SqlCommand cmd = new SqlCommand("SP_deleteStudent", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
