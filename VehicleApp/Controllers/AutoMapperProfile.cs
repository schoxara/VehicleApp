using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Service.Models;
using VehicleApp.Models;


namespace VehicleApp.Controllers
{
    public class AutoMapperProfile : Profile 
    {     

        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeView, IVehicleMake>()
                   .ReverseMap();

            CreateMap<VehicleModelView, IVehicleModel>()
                    .ReverseMap();
        }
    }
}