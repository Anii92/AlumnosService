using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Vueling.Autofac.Configuration;

namespace Vueling.Business.Facade.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacConfiguration.Build(Assembly.GetExecutingAssembly()));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
