using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace EventManagement.ApiControllers
{
    public class EventsController : BaseApiController
    {
        public EventsController(IEventRepository eventRepo):base(eventRepo)
        {
        }
        [Authorize]
        public IHttpActionResult GetAll()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return Ok(_eventRepo.All().ToList());
        }
    }
}