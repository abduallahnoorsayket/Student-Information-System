using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApp.Model.Model;

namespace WebApp.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext: DbContext
    {
        

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultDetails> ResultDetailses { get; set; }
    }
}
