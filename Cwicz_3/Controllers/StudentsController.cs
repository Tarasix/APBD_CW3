using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Cwicz_3.DAL;
//using Cwicz_3.Models;
using Cwicz_3.Models2;
using Cwicz_3.Services;
using Microsoft.AspNetCore.Mvc;



namespace Cwicz_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
       
        private readonly IStudentsDbService _dbContext;

        //public StudentsController(IStudentsDbService dbService)
        //{
        //    _dbService = dbService;

        //}

        public StudentsController(IStudentsDbService context)
        {
            _dbContext = context;
        }



        [HttpGet]
        public ActionResult GetStudents()
        {
            return Ok(_dbContext.GetStudents());
        }

        //[HttpPut("{id}")]
        //public IActionResult ChangeStudent(int id, Student student)
        //{

        //    return Ok("Aktualizacja dokonana");
        //}

        [HttpPut("{id}")]
        public IActionResult ModifyStudent(string id, string name, string surname,DateTime data)
        {
            return Ok(_dbContext.ModifyStudent(id, name, surname ,data));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            var response = _dbContext.DeleteStudent(id);

            if (response != null)
            {
                return Ok(response);
            }



            return NotFound("Nie mamy studentów");
        }


        ////[HttpGet]
        ////public IActionResult GetStudents()
        ////{
        ////    return Ok(_dbService.GetStudents());
        ////}

        //[HttpGet("{id}/enrollments")]
        //public IActionResult GetEnrollments(string id)
        //{
        //    var res = _dbService.GetEnrollments(id);

        //    if (res != null)
        //        return Ok(res);

        //    return NotFound();
        //}

        //[HttpPost]
        //public IActionResult CreateStudent(Student student)
        //{
        //    // creating in database
        //    student.IndexNumber = $"s{new Random().Next(1, 20000)}";
        //    return Ok(student);
        //}






    }
}

    