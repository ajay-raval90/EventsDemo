using EventManagement.DB.Interfaces;
using EventManagement.Filters;
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
        public EventsController(IEventRepository eventRepo) : base(eventRepo)
        {
        }
        //[AuthorizeApi]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;
            var eventList = _eventRepo.All(new string[] { "sessions", "location" }).ToList();
            foreach (var eve in eventList)
            {
                eve.sessions.ToList().ForEach(session =>
                {
                    session.voters = new string[] { };
                    if (session.VoterList != null)
                    {
                        session.voters = session.VoterList.Select(t => t.profile.FirstName).ToArray();
                    }

                });
            }
            return Ok(eventList);
        }

        [HttpGet]
        public IHttpActionResult GetById(int Id)
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;
            var eve = _eventRepo.Find(Id, new string[] { "sessions.VoterList.profile", "location" });
            eve.sessions.ToList().ForEach(session =>
            {
                session.voters = new string[] { };
                if (session.VoterList != null)
                {
                    session.voters = session.VoterList.Select(t => t.profile.FirstName).ToArray();
                }

            });
            return Ok(eve);
        }
    }
}