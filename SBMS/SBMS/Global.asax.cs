using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using System.Web.Http;
using SBMS.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SBMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            WebSecurity.InitializeDatabaseConnection("SBMS_DBContext", "Users", "UserId", "UserName", autoCreateTables: true);
        }
    }
}
