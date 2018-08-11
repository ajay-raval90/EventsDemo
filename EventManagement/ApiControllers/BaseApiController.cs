using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.ApiControllers
{
    public class BaseApiController : ApiController
    {
        public readonly IEventRepository _eventRepo;
        public BaseApiController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }
    }
}