using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using exampleAPI.Config;
using exampleAPI.Models;

namespace exampleAPI.Controllers
{

    public class StudentController : Controller
    {

        private DatabaseConnection db;

        public StudentController()
        {
            this.db = new Config.DatabaseConnection();
        }

        // GET: Student
        public ActionResult Index()
        {

            List<Student> students = new List<Student>();

            if (db.OpenConnection())
            {
                var cmd = db.command("SELECT * FROM students");
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

            ViewBag.students = students;

            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.title = "Register Student";

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection )
        {
            
            try
            {
                var strCommand = string.Format("INSERT INTO students (name,gender,address) VALUES ('{0}','{1}','{2}')", collection["name"], collection["gender"], collection["address"]);
                // TODO: Add insert logic here
                if (db.OpenConnection())
                {
                    var cmd = db.command(strCommand);
                    var reader = cmd.ExecuteReader();
                }
                    //return collection["name"]+","+collection["gender"]+","+collection["address"];
                    //Console.WriteLine(collection);
                    return RedirectToAction("Index");
                }
            catch
            {
                //return collection.ToString();
                return View();
                //return Content("");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var strCommand = string.Format("SELECT * FROM students WHERE id = {0}", id);
            var student = new Student();
            // TODO: Add insert logic here

            if (db.OpenConnection())
            {
                var cmd = db.command(strCommand);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student = new Student
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        gender = reader.GetString("gender"),
                        address = reader.GetString("address")
                    };
                }
            }
            // TODO: Add update logic here
            ViewBag.student = student;

            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
           

            try
            {
               

                return View();
                //return RedirectToAction("Student/Edit/"+id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var strCommand = string.Format("DELETE FROM students WHERE id = {0}", id);
                // TODO: Add insert logic here
                if (db.OpenConnection())
                {
                    var cmd = db.command(strCommand);
                    var reader = cmd.ExecuteReader();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        ~StudentController()
        {
            this.db.CloseConnection();
        }
    }
}
