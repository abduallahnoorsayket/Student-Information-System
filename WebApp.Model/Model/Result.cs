using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Model.Model
{
    public class Result
    {
        public Result()
        {
            ResultDetailses = new List<ResultDetails>();
        }

        public int Id { get; set; }
        public string StudentName { get; set; }
        public List<ResultDetails> ResultDetailses { get; set; }


    }
}
