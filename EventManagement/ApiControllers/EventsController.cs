using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.ApiControllers
{
    public class EventsController : BaseApiController
    {
        public EventsController(IEventRepository eventRepo):base(eventRepo)
        {
        }
        public IHttpActionResult GetAll()
        {
            return Ok(_eventRepo.All().ToList());
        }
    }
}