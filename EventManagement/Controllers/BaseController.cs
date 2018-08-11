using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
  
    public class BaseController : Controller
    {
        public readonly IEventRepository _eventRepo;
        public BaseController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }
    }
}