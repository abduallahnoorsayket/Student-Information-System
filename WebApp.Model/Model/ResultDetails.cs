using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Model.Model
{
    public class ResultDetails
    {

        public int Id { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }

        public int ResultId { get; set; }
        public Result Result { get; set; }

    }
}
