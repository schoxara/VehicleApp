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
using PagedList;
using PagedList.Mvc;

namespace VehicleApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;


        public VehicleModelController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }



        public async Task<ActionResult> Index(string search,int? i)
        {

            var items = await _vehicleService.GetAllVehicleModelAsync(search);
            return View(_mapper.Map<List<IVehicleModel>, List<VehicleModelView>>(items).ToPagedList(i?? 1,3));

        }
        // GET:/Create
        [HttpGet]
        public async Task<ActionResult> Create(string search)
        {
            var dropdown = await _vehicleService.GetAllVehicleMakeAsync( search);
            SelectList list = new SelectList(dropdown, "Id","Name","Abrv");
            ViewBag.VehicleNames = list;
            return View();

        }

        // POST:/Create
        [HttpPost]
        public async Task<ActionResult> Create(VehicleModelView newVehicle)
        {
            try
            {
                var successful = await _vehicleService.AddVehicleModelAsync(_mapper.Map<VehicleModelView, IVehicleModel>(newVehicle));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteVehicleModelAsync(Guid id)
        {
            if (id == null)
            {
                ViewBag.Message = "Id can't be empty!";
                // return (new { message = "Id can't be empty." });
            }

            await _vehicleService.DeleteVehicleModelAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }         

            var updateItem = await _vehicleService.GetVehicleModelAsync(id);
            return View(_mapper.Map<IVehicleModel, VehicleModelView>(updateItem));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(VehicleModelView newVehicle)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var name = newVehicle.Id;
            var successful = await _vehicleService.UpdateVehicleModelAsync(_mapper.Map<VehicleModelView, IVehicleModel>(newVehicle));

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> ListForOneMake(Guid Id)
        {

            var items = await _vehicleService.GetAllModelsForOneMake(Id);
            return PartialView(_mapper.Map<List<IVehicleModel>, List<VehicleModelView>>(items));

        }

    }
}