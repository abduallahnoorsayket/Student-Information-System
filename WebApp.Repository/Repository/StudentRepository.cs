using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.DatabaseContext.DatabaseContext;

namespace WebApp.Repository.Repository
{
    public class StudentRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public bool Add(Student student)
        {
            dbContext.Students.Add(student);
            //dbContext.SaveChanges();

            return dbContext.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            Student aStudent = dbContext.Students.FirstOrDefault(c => c.Id == id);

            dbContext.Students.Remove(aStudent);

            return dbContext.SaveChanges() > 0;
        }
        public bool Update(Student student)
        {
            //Method 1 
            //Student aStudent = dbContext.Students.FirstOrDefault(c => c.Id == student.Id);

            //if (aStudent !=null)
            //{
                
            //    aStudent.RollNo = student.RollNo;
            //    aStudent.Name = student.Name;
            //    aStudent.Address = student.Address;
            //    aStudent.Age = student.Age;
            //}

            //Method - 2
            dbContext.Entry(student).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public List<Student> GetAll()
        {
            return dbContext.Students.Include(c=>c.Department).ToList();
        }

        public Student GetBy(int id)
        {
            return dbContext.Students.First(c=>c.Id == id);
        }
    }
}
