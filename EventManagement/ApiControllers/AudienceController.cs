using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EventManagement.ApiControllers
{
    
    public class AudienceController : ApiController
    {
        IAudienceRepository _audRepo;
        public AudienceController(IAudienceRepository audRepo)
        {
            _audRepo = audRepo;
        }
        public IHttpActionResult Post(AudienceModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = _audRepo.AddAudience(audienceModel.Name);

            return Ok<Audience>(newAudience);

        }
    }
}