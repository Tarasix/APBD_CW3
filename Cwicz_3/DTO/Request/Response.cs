using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwicz_3.DTO.Request
{
    public class Response
    {
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudy { get; set; }
        public DateTime StartDate { get; set; }
    }
}
