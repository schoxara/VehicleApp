using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Models
{
        public class VehicleMake : IVehicleMake
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Abrv { get; set; }
            public List<IVehicleModel> VehicleModels { get; set; }
        }
    }

