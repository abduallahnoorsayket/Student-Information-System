using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.Repository.Repository;

namespace WebApp.BLL.BLL
{
    public class ResultManager
    {
        ResultRepository _resultRepository = new ResultRepository();
        public bool Add(Result result)
        {
            return _resultRepository.Add(result);
        }
    }
}
