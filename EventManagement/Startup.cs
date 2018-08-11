using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(EventManagement.Startup))]
namespace EventManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }

    }
}