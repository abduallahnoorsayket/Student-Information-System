using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AutoMapper;
using  WebApp.Models;
using  WebApp.Model.Model;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Initialize Automapper

            Mapper.Initialize(cfg => 
                {
                    cfg.CreateMap<StudentViewModel, Student>();
                    cfg.CreateMap< Student, StudentViewModel>();
                }
            );
        }
    }
}
