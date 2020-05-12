using Cwicz_3.DTO.Request;
using Cwicz_3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cwicz_3.Controllers
{

    [ApiController]
    [Route("api/enrollments")]

    public class EnrollmentsController : ControllerBase
    {
        private IStudentsDbService _dbService;

        public EnrollmentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;

        }

        [Route("api/promotions")]
        [HttpPost]
        public IActionResult PromoteStudent(PromoteStudentsRequests promote)
        {
            var res = _dbService.PromoteStudent(promote);
            return Ok(res);
        }
    }
}
   
        //    public EnrollmentsController(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }


    //    //[HttpPost]
    //    //[Authorize(Roles = "employee")]
    //    //public IActionResult EnrollStudent(EnrollStudentRequest request)
    //    //{
    //    //    try
    //    //    {
    //    //        return Created("", _dbService.EnrollStudent(request));
    //    //    }
    //    //    catch (Exception e)
    //    //    {
    //    //        return BadRequest();
    //    //    }
    //    //}


    //    [HttpPost("login")]
    //    public IActionResult Login(Student student)
    //    {

    //        var claims = new[]
    //        {
    //        new Claim(ClaimTypes.NameIdentifier, "1"),
    //        new Claim(ClaimTypes.Name, "jan123"),
    //        new Claim(ClaimTypes.Role, "adm"),
    //        new Claim(ClaimTypes.Role, "stud"),

    //        };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration
    //            ["SecretKey"])); 
    //            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //        var token = new JwtSecurityToken
    //            (
    //            issuer: "Gakko",
    //            audience: "Students",
    //            claims: claims,
    //            expires: DateTime.Now.AddMinutes(10),
    //            signingCredentials: creds

    //            );
    //        return Ok(new
    //        {
    //            accessToken = new JwtSecurityTokenHandler().WriteToken(token),
    //            refreshToken = Guid.NewGuid()
    //        });
    //    }

    //}

