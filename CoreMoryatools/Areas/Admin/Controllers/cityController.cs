using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using CoreMoryatools.Models.ViewModels;
using CoreMoryatools.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class cityController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public cityController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;

        }
        [HttpGet]
        public JsonResult getstatebyid(int id)
        {

            IList<state> obj = _unitofWork.state.GetAll().Where(x => x.countryid == id&&x.isdeleted==false).ToList();
            //  obj.Insert(0, new state  { id = 0, Name  = "select", countryid=0, isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "Name"));
        }
        public IActionResult Index()
        {
            ViewBag.countrylist = _unitofWork.country.GetAll().Where(x=>x.isdeleted==false).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countrylist = _unitofWork.country.GetAll().ToList();
            var model = new cityViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(cityViewModel model)
        {
            if (ModelState.IsValid)
            {

                var objcategory = new city
                {
                    id = model.id
                    ,
                    Name = model.Name
                    ,
                    stateid = model.stateid

                   ,
                    isdeleted = false
                    ,
                    isactive = false

                };

                _unitofWork.city .Add(objcategory);
                _unitofWork.Save();
                TempData["success"] = "Record Save successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.countrylist = _unitofWork.country.GetAll().ToList();
            var objcategory = _unitofWork.city.Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new cityViewModel()
            {
                id = objcategory.id,
                Name = objcategory.Name,
                stateid = objcategory.stateid,
                countryid = _unitofWork.state.Get(objcategory.stateid).countryid,
                isactive = objcategory.isactive,
                isdeleted = objcategory.isdeleted

            };
            ViewBag.States = _unitofWork.state.GetAll().Where(x => x.isdeleted == false && x.countryid == model.countryid);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(cityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.city.Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.Name = model.Name;
                storeobj.stateid = model.stateid;


                _unitofWork.city .Update(storeobj);
                _unitofWork.Save();
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }


        }




        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL(int stateid)
        {
            var obj = _unitofWork.city.GetAll().Where(x => x.isdeleted == false && x.stateid == stateid);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitofWork.city.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }
            obj.isdeleted = true;

            _unitofWork.city.Update(obj);
            _unitofWork.Save();
            return Json(new { success = true, message = "Delete Successfuly" });
        }
        #endregion
    }
}
