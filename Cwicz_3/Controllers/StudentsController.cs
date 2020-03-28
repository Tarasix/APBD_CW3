using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cwicz_3.DAL;
using Cwicz_3.Models;
using Microsoft.AspNetCore.Mvc;



namespace Cwicz_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        //private readonly IDbService _dbService;

        //public StudentsController(IDbService dbService)
        //{
        //    _dbService = dbService;
        //}

        [HttpGet]
        public IActionResult GetStudent()
        {
            //return Ok(_dbService.GetStudents());
            List<Student> students = new List<Student>();

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19461;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student " +
                    "inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment" +
                    " inner join Studies on Studies.IdStudy = Enrollment.IdStudy";

                con.Open();

                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var st = new Student();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.StudiesName = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    students.Add(st);
                }

                return Ok(students);

            }
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(String id)
        {
            List<Enrollment> enrolments = new List<Enrollment>();

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19461;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = ("select Enrollment.IdEnrollment, Semester, IdStudy,StartDate from Student " +
                    "inner join Enrollment on Enrollment.IdEnrollment = Student.IdEnrollment" +
                    $" where IndexNumber=@id;");
                com.Parameters.AddWithValue("id", id);

                con.Open();

                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var enr = new Enrollment();
                    enr.Semester = Convert.ToInt32(dr["Semester"]);
                    enr.IdStudy = Convert.ToInt32(dr["IdStudy"]);
                    enr.IdEnrollment = Convert.ToInt32(dr["IdEnrollment"]);
                    enr.StartDate = dr["StartDate"].ToString();
                    enrolments.Add(enr);
                }

                return Ok(enrolments);
            }
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult AlterStudent(int id)
        {
            return Ok("Aktualizacja dokonczona");
        }

        [HttpDelete("{id}")]
        public IActionResult DropStudent(int id)
        {
            return Ok("Usuwanie ukonczone");
        }


    }
}