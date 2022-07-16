﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UnipaMiniTask.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialise();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
        // SameSite problemi - ??Z?M 3
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //SameSiteCookieRewriter.FilterSameSiteNoneForIncompatibleUserAgents(sender);
        }
    }
}
