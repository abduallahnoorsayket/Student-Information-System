using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.Repository.Repository;

namespace WebApp.BLL.BLL
{
    public class DepartmentManager
    {
        DepartmentRepository _departmentRepository = new DepartmentRepository();
        public bool Add(Department department)
        {
            return _departmentRepository.Add(department);
        }
        public bool Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }
        public bool Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
        public Department GetByID(int id)
        {
            return _departmentRepository.GetBy(id);
        }
    }
}
