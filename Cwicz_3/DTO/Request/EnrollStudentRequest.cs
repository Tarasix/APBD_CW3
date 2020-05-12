using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwicz_3.DTO.Request
{
    public class EnrollStudentRequest
    {
        public string IndexNumber { get; set; }
     
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
     
        public DateTime BirthDate { get; set; }
     
        public string Studies { get; set; }
    }
}
