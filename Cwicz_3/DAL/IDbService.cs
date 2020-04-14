using Cwicz_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwicz_3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
      
    }







}
