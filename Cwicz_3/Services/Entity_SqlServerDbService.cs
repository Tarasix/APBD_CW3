using Cwicz_3.DTO.Request;
using Cwicz_3.Models2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace Cwicz_3.Services
{
    public class Entity_SqlServerDbService : IStudentsDbService
    {
        private readonly s19461Context _dbContext;
      
        public Entity_SqlServerDbService(s19461Context context)
        {
            _dbContext = context;
        }
        
        public IEnumerable<Student> GetStudents()
        {
            var db = new s19461Context();
            return db.Student.ToList();
        }



        public Student ModifyStudent(string id, string name, string surname,DateTime data)
        {
            var db = new s19461Context();
            var student = db.Student.SingleOrDefault(x => x.IndexNumber == id);

            if (name != null && student != null)
                student.FirstName = name;
            
            
            if (surname != null && student != null)
                student.LastName = surname;
          
            
            if (data != null && student != null)
                student.BirthDate = data;

            db.SaveChanges();
            return student;
        }

        public Student DeleteStudent(string id)
        {
            var db = new s19461Context();
            var student = db.Student.SingleOrDefault(x => x.IndexNumber == id);

            if (student != null)
                db.Remove(student);

            db.SaveChanges();
            return student;
        }

        public IEnumerable<Response> PromoteStudent(PromoteStudentsRequests psrequest)
        {
            var db = new s19461Context();
            var responsesList = new List<Response>();
           
            var study = db.Studies.Where(s => s.Name == psrequest.Studies).FirstOrDefault();
           
            var enrollment = db.Enrollment.Where(e => e.Semester == psrequest.Semester && e.IdStudy == study.IdStudy).First();
           
            var newEnrollment = db.Enrollment.Where(e => e.Semester == psrequest.Semester + 1 && e.IdStudy == study.IdStudy).FirstOrDefault();
           
            var newIdEnrollment = db.Enrollment.Max(e => e.IdEnrollment) + 1;
            if (newEnrollment == null)
            {
                db.Enrollment.Add(new Enrollment
                {
                    IdEnrollment = newIdEnrollment,
                    Semester = psrequest.Semester + 1,
                    IdStudy = study.IdStudy,
                    StartDate = DateTime.Now


                });
            
                newEnrollment = db.Enrollment.Where(e => e.Semester == psrequest.Semester + 1 && e.IdStudy == study.IdStudy).FirstOrDefault();
            }
          
            var studentsList = db.Student.Where(student => student.IdEnrollment == enrollment.IdEnrollment).ToList();

            foreach (var student in studentsList)
            {
                student.IdEnrollment = newEnrollment.IdEnrollment;
            }

       
            var psresponse = new Response
            {
                IdEnrollment = newEnrollment.IdEnrollment,
                Semester = psrequest.Semester + 1,
                IdStudy = study.IdStudy,
                StartDate = DateTime.Now

            };
            responsesList.Add(psresponse);
            return responsesList;


        }

        public Response EnrollStudent(EnrollStudentRequest request)
        {
            var db = new s19461Context();

            using (var dbTran = db.Database.BeginTransaction())
            {
                try
                {
                    var idStudies = db.Studies.SingleOrDefault(x => x.Name == request.Studies);
                    if (idStudies == null)
                        throw new Exception();

                    if (db.Enrollment.Where(x => x.Semester == 1)
                        .SingleOrDefault(x => x.IdStudy == idStudies.IdStudy) == null)
                    {
                        db.Enrollment.Add(new Enrollment
                        {
                            IdEnrollment = db.Enrollment.Max(x => x.IdEnrollment) + 1,
                            Semester = 1,
                            IdStudy = idStudies.IdStudy,
                            StartDate = DateTime.Now
                        });
                    }

                    db.Student.Add(new Student
                    {
                        IndexNumber = request.IndexNumber,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        BirthDate = request.BirthDate,
                        IdEnrollment = db.Enrollment.Where(x => x.Semester == 1)
                            .Where(x => x.IdStudy == idStudies.IdStudy)
                            .Select(x => x.IdEnrollment).First()
                    });

                    db.SaveChanges();
                    dbTran.Commit();
                    return db.Enrollment.Where(x => x.Semester == 1)
                        .Where(x => x.IdStudy == idStudies.IdStudy).Select(x => new Response
                        {
                            IdEnrollment = x.IdEnrollment,
                            IdStudy = x.IdStudy,
                            Semester = x.Semester,
                            StartDate = x.StartDate
                        }).First();
                }
                catch (Exception)
                {
                    dbTran.Rollback();
                    return null;
                }
            }
        }

    
    }
}
//private const string ConStr = "Data Source=db-mssql;Initial Catalog=s19461;Integrated Security=True";

//public IEnumerable<Student> GetStudents()
//{
//    var students = new List<Student>();
//    using (var con = new SqlConnection(ConStr))
//    {
//        using var com = new SqlCommand()
//        {
//            Connection = con,
//            CommandText = "select * from Student"
//        };
//        con.Open();
//        var rd = com.ExecuteReader();
//        while (rd.Read())
//        {
//            students.Add(new Student
//            {
//                IndexNumber = rd["IndexNumber"].ToString(),
//                FirstName = rd["FirstName"].ToString(),
//                LastName = rd["LastName"].ToString(),
//                BirthDate = rd["BirthDate"].ToString(),
//                IdEnrollment = IntegerType.FromObject(rd["IdEnrollment"])
//            });
//        }
//    }

//    return students;
//}

//public IEnumerable<Enrollment> GetEnrollments(string id)
//{
//    var enrollments = new List<Enrollment>();
//    using (var con = new SqlConnection(ConStr))
//    {
//        using var com = new SqlCommand()
//        {
//            Connection = con,
//            CommandText = $"SELECT * FROM Enrollment e JOIN Student s on e.IdEnrollment = s.IdEnrollment where s.IndexNumber = @id"
//        };
//        com.Parameters.AddWithValue("id", id);
//        con.Open();
//        var rd = com.ExecuteReader();
//        while (rd.Read())
//        {
//            enrollments.Add(new Enrollment()
//            {
//                IdEnrollment = IntegerType.FromObject(rd["IdEnrollment"]),
//                Semester = IntegerType.FromObject(rd["Semester"]),
//                IdStudy = IntegerType.FromObject(rd["IdStudy"]),
//                StartDate = rd["StartDate"].ToString()
//            });
//        }
//    }

//    return enrollments;
//}

//public Enrollment EnrollStudent(EnrollStudentRequest request)
//{

//    if (request.Studies == null
//        || request.BirthDate == null
//        || request.FirstName == null
//        || request.IndexNumber == null
//        || request.LastName == null)
//    {
//        throw new Exception();
//    }

//    Enrollment enrollment;

//    using (var con = new SqlConnection(ConStr))
//    {
//        con.Open();


//        var study = getStudy(con, request.Studies);

//        if (study == null)
//        {
//            throw new Exception();
//        }

//        enrollment = getLastEnrollmentForStudy(con, study.Idstudy);

//        var transaction = con.BeginTransaction();

//        if (enrollment == null)
//        {
//            enrollment = new Enrollment()
//            {
//                Semester = 1,
//                IdStudy = study.Idstudy,
//                StartDate = DateTime.Now.ToString("MM.dd.yyyy")
//            };
//            saveEnrollment(con, enrollment, transaction);
//        }

//        if (checkIfExists(con, request.IndexNumber, transaction))
//        {
//            transaction.Rollback();
//            throw new Exception();
//        }

//        var student = new Student()
//        {
//            IndexNumber = request.IndexNumber,
//            FirstName = request.FirstName,
//            LastName = request.LastName,
//            BirthDate = request.BirthDate,
//            IdEnrollment = IntegerType.FromObject(enrollment.IdEnrollment)
//        };

//        saveStudent(con, student, transaction);
//        transaction.Commit();

//    }

//    return enrollment;
//}

//public Enrollment PromoteStudents(PromoteStudentsRequests request)
//{
//    using var con = new SqlConnection(ConStr);
//    con.Open();

//    var enrollment = getEnrollment(con, request.Studies, request.Semester);

//    if (enrollment == null)
//    {
//        throw new Exception();
//    }

//    using var com = new SqlCommand()
//    {
//        Connection = con
//    };

//    com.CommandText = $"PromoteStudents";
//    com.CommandType = CommandType.StoredProcedure;

//    com.Parameters.AddWithValue("Studies", request.Studies);
//    com.Parameters.AddWithValue("Semester", request.Semester);

//    com.ExecuteNonQuery();

//    enrollment.Semester++;

//    return enrollment;
//}

//private Studies getStudy(SqlConnection con, string name)
//{
//    using var com = new SqlCommand()
//    {
//        Connection = con
//    };
//    com.CommandText = $"SELECT * FROM Studies WHERE Name = @name";
//    com.Parameters.AddWithValue("name", name);
//    var rd = com.ExecuteReader();
//    while (rd.Read())
//    {
//        var study = new Studies()
//        {
//            Idstudy = IntegerType.FromObject(rd["IdStudy"]),
//            Studiess = rd["Name"].ToString()
//        };
//        rd.Close();
//        return study;
//    }
//    return null;
//}

//private Enrollment getEnrollment(SqlConnection con, string name, int semester)
//{
//    using var com = new SqlCommand()
//    {
//        Connection = con
//    };
//    com.CommandText = $"SELECT * FROM Enrollment JOIN Studies ON Enrollment.IdStudy = Studies.IdStudy WHERE Semester = @semester AND Name = @name";
//    com.Parameters.AddWithValue("name", name);
//    com.Parameters.AddWithValue("semester", semester);
//    var rd = com.ExecuteReader();
//    while (rd.Read())
//    {
//        var enrollment = new Enrollment()
//        {
//            IdEnrollment = IntegerType.FromObject(rd["IdEnrollment"]),
//            Semester = IntegerType.FromObject(rd["Semester"]),
//            IdStudy = IntegerType.FromObject(rd["IdStudy"]),
//            StartDate = rd["StartDate"].ToString()
//        };
//        rd.Close();
//        return enrollment;
//    }

//    return null;
//}

//private Enrollment getLastEnrollmentForStudy(SqlConnection con, int id)
//{
//    using var com = new SqlCommand()
//    {
//        Connection = con
//    };
//    com.CommandText = $"SELECT * FROM Enrollment WHERE IdStudy = @id AND Semester = 1";
//    com.Parameters.AddWithValue("id", id);

//    var rd = com.ExecuteReader();
//    while (rd.Read())
//    {
//        var enrollment = new Enrollment()
//        {
//            IdEnrollment = IntegerType.FromObject(rd["IdEnrollment"]),
//            Semester = IntegerType.FromObject(rd["Semester"]),
//            IdStudy = IntegerType.FromObject(rd["IdStudy"]),
//            StartDate = rd["StartDate"].ToString()
//        };
//        rd.Close();
//        return enrollment;
//    }
//    return null;
//}

//private void saveStudent(SqlConnection con, Student student, SqlTransaction transaction)
//{
//    using var com = new SqlCommand()
//    {
//        Transaction = transaction,
//        Connection = con
//    };
//    com.CommandText =
//        $"INSERT INTO Student VALUES (@IndexNumber, @FirstName, @LastName, @BirthDate, @IdEnrollment)";
//    com.Parameters.AddWithValue("IndexNumber", student.IndexNumber);
//    com.Parameters.AddWithValue("FirstName", student.FirstName);
//    com.Parameters.AddWithValue("LastName", student.LastName);
//    com.Parameters.AddWithValue("BirthDate", student.BirthDate);
//  //  com.Parameters.AddWithValue("IdEnrollment", student.IdEnrollment);
//    com.ExecuteNonQuery();
//}

//private bool checkIfExists(SqlConnection con, string indexNumber, SqlTransaction transaction)
//{
//    using var com = new SqlCommand()
//    {
//        Connection = con,
//        Transaction = transaction
//    };
//    com.CommandText = $"SELECT * FROM Student WHERE IndexNumber=@indexNumber";
//    com.Parameters.AddWithValue("indexNumber", indexNumber);
//    var rd = com.ExecuteReader();
//    while (rd.Read())
//    {
//        rd.Close();
//        return true;
//    }
//    rd.Close();
//    return false;
//}

//public bool checkIfExists(string indexNumber)
//{
//    using (var con = new SqlConnection(ConStr))
//    {
//        using (var com = new SqlCommand())
//        {
//            con.Open();
//            com.Connection = con;
//            com.CommandText = $"SELECT * FROM Student WHERE IndexNumber=@indexNumber";
//            com.Parameters.AddWithValue("indexNumber", indexNumber);
//            var rd = com.ExecuteReader();
//            while (rd.Read())
//            {
//                rd.Close();
//                return true;
//            }
//            rd.Close();
//        }
//    }
//    return false;
//}

//private void saveEnrollment(SqlConnection con, Enrollment enrollment, SqlTransaction transaction)
//{
//    using var com = new SqlCommand()
//    {
//        Transaction = transaction,
//        Connection = con,
//        CommandText = $"INSERT INTO Enrollment SELECT NULLIF(MAX(E.IdEnrollment) + 1, 0), @Semester, @IdStudy, @StartDate"
//    };
//    com.Parameters.AddWithValue("Semester", enrollment.Semester);
//    com.Parameters.AddWithValue("IdStudy", enrollment.IdStudy);
//    com.Parameters.AddWithValue("StartDate", enrollment.StartDate);
//    com.ExecuteNonQuery();
//}

//public bool CheckIfExists(string index)
//{
//    using (SqlConnection con = new SqlConnection(ConStr))
//    using (SqlCommand com = new SqlCommand())
//    {
//        com.Connection = con;
//        con.Open();

//        com.CommandText = "select * from students where IndexNumber=@tmpId";
//        com.Parameters.AddWithValue("@tmpId", index);
//        SqlDataReader dr = com.ExecuteReader();

//        return dr.HasRows;
//    }
//}

//  }
//}


