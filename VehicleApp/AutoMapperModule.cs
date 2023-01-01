using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using VehicleApp.Controllers;
using Service;
using VehicleApp.Models;
using Service.Models;

namespace VehicleApp
{
    public class AutoMapperModule : Module
    {

        public static void ConfigureAutomapperModule(ContainerBuilder builder)
        {
           // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes

           builder.RegisterType<VehicleMakeView>().SingleInstance();

            //register all profile classes in the calling assembly

            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<AutoMapperProfile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
               // foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(new AutoMapperProfile());
                    cfg.AddProfile(new ServiceProfile());
                    //   cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
               .As<IMapper>()
                .InstancePerLifetimeScope();
        }

    }

}
