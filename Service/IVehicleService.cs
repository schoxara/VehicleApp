using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;
using X.PagedList;

namespace Service
{
    public interface IVehicleService
    {
        // Make
        Task<IVehicleMake> GetVehicleMakeAsync(Guid id);
        Task<List<IVehicleMake>> GetAllVehicleMakeAsync(string search);
        Task<IVehicleMake> AddVehicleMakeAsync(IVehicleMake vehicleMake);
        Task<bool> UpdateVehicleMakeAsync(IVehicleMake vehicleMakeUpdate);
        Task<bool> DeleteVehicleMakeAsync(Guid id);
        //Task<IVehicleMake> GetVehicleMakeAbrv(string abrv);
        
        // Model
        Task<IVehicleModel> GetVehicleModelAsync(Guid id);
        Task<List<IVehicleModel>> GetAllVehicleModelAsync(string search);
        Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel vehicleModel);
        Task<bool> UpdateVehicleModelAsync(IVehicleModel vehicleModelUpdate);
        Task<bool> DeleteVehicleModelAsync(Guid id);
        Task<List<IVehicleModel>> GetAllModelsForOneMake(Guid Id);
    }
}
