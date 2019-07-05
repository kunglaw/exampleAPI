using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using exampleAPI.Config;
using exampleAPI.Models;
using Newtonsoft.Json;

namespace exampleAPI.Controllers
{

    public class StudentApiController : ApiController
    {

        //private DBConnection db;
        private DatabaseConnection db;

        public StudentApiController()
        {
            //this.db = Config.DBConnection.Instance(); // connect terus 
            this.db = new Config.DatabaseConnection();
        }

        // GET: api/Student
        public object Get()
        {
            List<Student> students = new List<Student>();

            if (db.OpenConnection())
            {
                var cmd = this.db.command("SELECT * FROM students");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        gender = reader.GetString("gender"),
                        address = reader.GetString("address")
                    });
                }
            }
            


            //if (db.IsConnect())
            //{
            //    //suppose col0 and col1 are defined as VARCHAR in the DB
            //    string query = "SELECT * FROM students";
            //    var cmd = new MySqlCommand(query, db.Connection);
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        students.Add(new Student
            //        {
            //            id = reader.GetInt32("id"),
            //            name = reader.GetString("name"),
            //            gender = reader.GetString("gender"),
            //            address = reader.GetString("address")
            //        });
            //    }

            //}

            //student[] students = new student[]
            //{
            //    ,
            //    new student
            //    {
            //        id = 2,
            //        name = "ari",
            //        gender = "male",
            //        address = "hello world"
            //    }
            //};

            //Student studentOut = new Student();

            //return studentOut.blackhole();
            //return JsonConvert.SerializeObject(students);
            return students;
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }

        ~StudentApiController()
        {
            //this.db.Close();
            db.CloseConnection();
        }
    }
}
