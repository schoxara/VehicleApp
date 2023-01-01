using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Service.Models;

namespace Service
{
    public class ModuleService : Module
    {


        public static void ConfigureServiceModule(ContainerBuilder builder)
        {
            // builder.RegisterType<ClassName>().As<InterfaceName>(); for new Classes
            builder.RegisterType<VehicleMake>().As<IVehicleMake>();
            builder.RegisterType<VehicleModel>().As<IVehicleModel>();
            builder.RegisterType<VehicleService>().As<IVehicleService>();

            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(ModuleService).Assembly).As<ServiceProfile>();

            //builder.Register(context => new MapperConfiguration(cfg =>
            //{
            //   // foreach (var profile in context.Resolve<IEnumerable<Profile>>())
            //    {
            //        cfg.AddProfile(new ServiceProfile());
            //    }
            //})).AsSelf().SingleInstance();

            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            //   .As<IMapper>()
            //    .InstancePerLifetimeScope();
        }

    }
    }

