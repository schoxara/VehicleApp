using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using VehicleApp.Controllers;
using Service;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using Microsoft.Extensions.Configuration;
using VehicleApp.App_Start;


namespace VehicleApp
{
    public class MvcApplication : HttpApplication
    {
        // private static IContainer Container { get; set; }
        public IConfiguration Configuration { get; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.ConfigureDependencyInjection();
        
            /* var builder = new ContainerBuilder();
             builder.RegisterControllers(typeof(MvcApplication).Assembly);
             ModuleService.ConfigureServiceModule(builder);
             builder.RegisterInstance(mapper).As<IMapper>();
             Container = builder.Build();

             DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
             */
        }
    }
}
