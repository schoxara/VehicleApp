using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;
using PagedList.Mvc;
using X.PagedList;



namespace VehicleApp.Models
{
    public class VehicleMakeView
    {
        public IVehicleMake[] VehicleMakes { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleMakeView> VehicleModels { get; set; }
    }
}