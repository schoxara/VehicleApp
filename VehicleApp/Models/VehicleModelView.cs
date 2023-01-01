using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace VehicleApp.Models
{
    public class VehicleModelView
    {
        public IVehicleModel[] VehicleModels { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid MakeId { get; set; }
        public List<VehicleModelView> VehicleMakes { get; set; }
    }
}