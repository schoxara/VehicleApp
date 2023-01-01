using System;
using Autofac;
using Service;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using AutoMapper;
using VehicleApp.Controllers;
using Microsoft.Extensions.Configuration;

namespace VehicleApp.App_Start
{
    public class AutofacConfig
    {
        private static IContainer Container { get; set; }
        public IConfiguration Configuration { get; }

       
        public static void ConfigureDependencyInjection()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutoMapperProfile());
            //    cfg.AddProfile(new ServiceProfile());
            //});
            //var mapper = config.CreateMapper();

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);                     
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new ModuleService());
            builder.RegisterType<VehiclesDBEntities>().InstancePerRequest();
            AutoMapperModule.ConfigureAutomapperModule(builder);
            ModuleService.ConfigureServiceModule(builder);            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}