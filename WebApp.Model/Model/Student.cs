using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Model.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string RollNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
