using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;   
using AutoMapper;
using System.Threading.Tasks;
using Service;
using VehicleApp.Models;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace VehicleApp.Controllers
{
    public class VehicleMakeController : Controller
    {

        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;


        public VehicleMakeController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<ActionResult> IndexVehicle(string search,int? i)
        {

            var items = await _vehicleService.GetAllVehicleMakeAsync(search);
            return View(_mapper.Map<List<IVehicleMake>, List<VehicleMakeView>>(items).ToPagedList(i?? 1,3));

        }
        // GET:/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST:/Create
        [HttpPost]
        public async Task<ActionResult> Create(VehicleMakeView newVehicle)
        {
            try
            {
                var successful = await _vehicleService.AddVehicleMakeAsync(_mapper.Map<VehicleMakeView, IVehicleMake>(newVehicle));

                //var successfulModel = await _vehicleService.AddVehicleModelAsync(_mapper.Map<VehicleModelView, IVehicleModel>(newModel));

                return RedirectToAction("IndexVehicle");
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> DeleteVehicleMakeAsync(Guid id)
        {
            if (id == null)
            {
                ViewBag.Message = "Id can't be empty!";
               // return (new { message = "Id can't be empty." });
            }

            await _vehicleService.DeleteVehicleMakeAsync(id);
            return RedirectToAction("IndexVehicle");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IndexVehicle");
            }
            //var successful = await _vehicleService.UpdateVehicleMakeAsync(_mapper.Map<VehicleMakeView, IVehicleMake>(updateVehicleMake));

            var updateItem = await _vehicleService.GetVehicleMakeAsync(id);

            //if (successful == null)
            //{
            //    return BadRequest("Could not add vehicle.");
            //}

            return View(_mapper.Map<IVehicleMake, VehicleMakeView>(updateItem));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(VehicleMakeView newVehicle)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IndexVehicle");
            }
            //var successful = await vehicleMakeService.UpdateVehicleMakeAsync(_mapper.Map<VehicleMakeViewModel, IVehicleMake>(updateVehicleMake));
            var name = newVehicle.Id;
            var successful = await _vehicleService.UpdateVehicleMakeAsync(_mapper.Map<VehicleMakeView, IVehicleMake>(newVehicle));

            //if (successful == null)
            //{
            //    return BadRequest("Could not add vehicle.");
            //}


            return RedirectToAction("IndexVehicle");
        }




    }
}