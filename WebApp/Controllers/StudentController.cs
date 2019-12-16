using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Model.Model;
using  WebApp.BLL.BLL;
using WebApp.Models;
using  AutoMapper;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();

        //public string Add(string rollNo, string name, string address, int ? age, int ? departmentId)
        [HttpGet]
        public ActionResult Add()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(), Text = c.Name

                    }
                ).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Add(student))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();


            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Search(StudentViewModel studentViewModel)
        {
            var students = _studentManager.GetAll();

            if (studentViewModel.RollNo != null)
            {
                students = students.Where(c=>c.RollNo.Contains(studentViewModel.RollNo)).ToList();

            }

            if (studentViewModel.Name != null)
            {
                students = students.Where(c => c.Name.ToLower().Contains(studentViewModel.Name.ToLower())).ToList();
            }

            studentViewModel.Students = students;
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();

            return View(studentViewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var student = _studentManager.GetByID(id);

            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;

            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Update(student))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();


            return View(studentViewModel);
        }

        //////////////////////////////////////////////////////////////

        public ActionResult StudentDetails()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.DepartmentSelectListItems = _departmentManager.GetAll()
                .Select(c=> new  SelectListItem(){Value = c.Id.ToString(), Text = c.Name}).ToList();

            ViewBag.Department = studentViewModel.DepartmentSelectListItems;
            return View();
        }

        public JsonResult GetStudentByDepartmentId(int departmentId)
        {
            var studentList= _studentManager.GetAll().Where(c=>c.DepartmentId == departmentId).ToList();
            var students = studentList.Select(c => new {c.Id, c.Name}).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        //PartialView
        public ActionResult GetStudentById(int studentId)
        {
            var student = _studentManager.GetByID(studentId);
            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);
            studentViewModel.Students = _studentManager.GetAll();
            return PartialView("student/_StudentDetails", studentViewModel);
        }

        //Unique
        public JsonResult RollNoIsExists(string rollNo)
        {
            var students = _studentManager.GetAll().Where(c => c.RollNo == rollNo).ToList();
            bool rollNoIsExists = false;
            if (students.Count >0)
                rollNoIsExists = true;

            return Json(rollNoIsExists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentByRollNoId(int studentId)
        {
            var studentList = _studentManager.GetAll().Where(c => c.Id == studentId).ToList();
            var students = studentList.Select(c => new { c.RollNo});
            return Json(students, JsonRequestBehavior.AllowGet);
        }


    }
}
