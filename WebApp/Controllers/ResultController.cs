using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BLL.BLL;
using WebApp.Model.Model;

namespace WebApp.Controllers
{
    public class ResultController : Controller
    {
        ResultManager _resultManager = new ResultManager();
        // GET: Result


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Result result)
        {
            ////Result result = new Result()
            //{
            //    StudentName = "Ali",
            //    ResultDetailses = new List<ResultDetails>()
            //    {
            //        new ResultDetails(){Subject = "Math", Marks = 60},
            //        new ResultDetails(){Subject = "Math", Marks = 80},
            //        new ResultDetails(){Subject = "Math", Marks = 85},
            //    }
            //};


            _resultManager.Add(result);

            return View();
        }
    }
}