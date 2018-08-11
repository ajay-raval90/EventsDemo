using EventManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        EventDbContext context;
        public HomeController()
        {
            context = new EventDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.Profiles =  context.Profiles.ToList();
            

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
