using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Models
{
       public interface IVehicleMake
        {
            Guid Id { get; set; }
            string Name { get; set; }
            string Abrv { get; set; }
            List<IVehicleModel> VehicleModels { get; set; }
    }
}
