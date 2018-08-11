using EventManagement.DB;
using EventManagement.DB.Interfaces;
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
            //ViewBag.Profiles =  context.Profiles.ToList();

            ViewBag.Events =_eventRepo.All().ToList();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
