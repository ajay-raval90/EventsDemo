using EventManagement.DB;
using EventManagement.DB.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class HomeController : BaseController
    {

        //private readonly IEventRepository _eventRepo;
        public HomeController(IEventRepository eventRepo):base(eventRepo)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
