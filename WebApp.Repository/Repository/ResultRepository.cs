using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DatabaseContext.DatabaseContext;
using WebApp.Model.Model;

namespace WebApp.Repository.Repository
{
    public class ResultRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public bool Add(Result result)
        {
            dbContext.Results.Add(result);
            //dbContext.SaveChanges();

            return dbContext.SaveChanges() > 0;
        }
    }
}
