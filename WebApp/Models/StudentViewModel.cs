using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Roll No is Required!!!")]
        [MaxLength(4, ErrorMessage = "Must be 3 char in Lenght")]
        public string RollNo { get; set; }
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Student> Students { get; set; }
        public List<SelectListItem> DepartmentSelectListItems { get; set; }
    }
}