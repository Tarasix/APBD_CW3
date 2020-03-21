using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwicz_3.DAL;
using Cwicz_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwicz_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;

        public StudentsController(IDbService service)
        {
            _dbService = service;
        }


        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult UsunStudenta(int id)
        {
            return Ok("Usuwanie ukonczone");
        }

        [HttpPut("{id}")]
        public IActionResult UpdStudent(int id)
        {
            return Ok("Aktualizacja dokonczona");
        }

    }
}