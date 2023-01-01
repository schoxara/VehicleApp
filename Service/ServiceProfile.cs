using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Service.Models;


namespace Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Make, IVehicleMake>().ReverseMap();
            CreateMap<Model, IVehicleModel>().ReverseMap();
        }
    }
}
