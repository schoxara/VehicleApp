using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using X.PagedList;

namespace Service
{
    public class VehicleService : IVehicleService
    {
        protected VehiclesDBEntities Context{get; set;}
        private readonly IMapper _mapper;
        private readonly VehiclesDBEntities _Context;

        public VehicleService(VehiclesDBEntities context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public async Task<IVehicleMake> AddVehicleMakeAsync(IVehicleMake vehicleMake)
        {           
            vehicleMake.Id = Guid.NewGuid();
            _Context.Make.Add(_mapper.Map<IVehicleMake, Make>(vehicleMake));
            await _Context.SaveChangesAsync();
               
            return vehicleMake;
        }

        public async Task<bool> DeleteVehicleMakeAsync(Guid id)
        {
            var delteVehicleMake = await _Context.Make.SingleOrDefaultAsync(x => x.Id == id);
            if (delteVehicleMake != null)
            {
                _Context.Make.Remove(delteVehicleMake);
                await _Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<IVehicleMake>> GetAllVehicleMakeAsync(string search)
        {
            var allVehicleMakes = await _Context.Make.OrderBy(x => x.Name).Where(x => x.Name.StartsWith(search) || search == null).ToListAsync();
            return _mapper.Map<List<IVehicleMake>>(allVehicleMakes);
        }
     
        public async Task<IVehicleMake> GetVehicleMakeAsync(Guid id)
        {
            var getVehicleMake = await _Context.Make.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<IVehicleMake>(getVehicleMake);
        }

        public async Task<bool> UpdateVehicleMakeAsync(IVehicleMake vehicleMakeUpdate)
        {
            Guid id = vehicleMakeUpdate.Id;
            var entity = await _Context.Make.SingleOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = vehicleMakeUpdate.Name;
                entity.Abrv = vehicleMakeUpdate.Abrv;

                //_Context.Make.Update(entity);
                _Context.SaveChanges();
            }
            return true;
        }

        //////////////////////////////////////////  Model //////////////////////////////////////////////////////////////
        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel vehicleModel)
        {
            vehicleModel.Id = Guid.NewGuid();

            _Context.Model.Add(_mapper.Map<IVehicleModel, Model>(vehicleModel));
            await _Context.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<bool> DeleteVehicleModelAsync(Guid id)
        {
            var delteVehicleModel = await _Context.Model.SingleOrDefaultAsync(x => x.Id == id);
            if (delteVehicleModel != null)
            {
                _Context.Model.Remove(delteVehicleModel);
                await _Context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<IVehicleModel>> GetAllVehicleModelAsync(string search)
        {
            var allVehicleModel = await _Context.Model.OrderBy(x => x.Name).Where(x => x.Name.StartsWith(search) || search == null).ToListAsync();
            return _mapper.Map<List<IVehicleModel>>(allVehicleModel);
        }
            
        public async Task<IVehicleModel> GetVehicleModelAsync(Guid id)
        {
           var getVehicleModel = await _Context.Model.SingleOrDefaultAsync(x => x.MakeId == id);
           return _mapper.Map<IVehicleModel>(getVehicleModel);
        }

        public async Task<bool> UpdateVehicleModelAsync(IVehicleModel vehicleModelUpdate)
        {
            Guid id = vehicleModelUpdate.Id;
            var entity = await _Context.Model.SingleOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = vehicleModelUpdate.Name;
                entity.Abrv = vehicleModelUpdate.Abrv;
              
                _Context.SaveChanges();
            }
            return true;
        }
        // Get all models for one make by Id
        public async Task<List<IVehicleModel>> GetAllModelsForOneMake(Guid Id)
        {                   
            var allVehicleModel = await _Context.Model.OrderBy(x => x.Name).Where(x=> x.MakeId==Id).ToListAsync();
            return _mapper.Map<List<IVehicleModel>>(allVehicleModel);
        }
    }        
}


