using Cwicz_3.DTO.Request;
using Cwicz_3.Models2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cwicz_3.Services
{
    public interface IStudentsDbService
    {
        //public IEnumerable<Student> GetStudents();
        //public IEnumerable<Enrollment> GetEnrollments(string id);
        //public Enrollment EnrollStudent(EnrollStudentRequest request);
        //public Enrollment PromoteStudents(PromoteStudentsRequests request);
        //public bool CheckIfExists(string index);

        public IEnumerable<Response> PromoteStudent(PromoteStudentsRequests psr);
        public IEnumerable<Student> GetStudents();
        public Student ModifyStudent(string id, string name, string surname,DateTime data);
        public Student DeleteStudent(string id);
        public Response EnrollStudent(EnrollStudentRequest request);
      

    }
}
