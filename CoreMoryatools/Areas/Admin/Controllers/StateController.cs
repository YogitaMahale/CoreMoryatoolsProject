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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StateController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public StateController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;

        }
        public IActionResult Index()
        {
            ViewBag.countrylist = _unitofWork.country.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countrylist = _unitofWork.country.GetAll().ToList();
            var model = new StateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var objcategory = new state
                {
                    id = model.id
                    ,
                    Name = model.Name
                    ,
                    countryid = model.countryid

                   ,
                    isdeleted = false
                    ,
                    isactive = false

                };

                _unitofWork.state.Add(objcategory);
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
            var objcategory = _unitofWork.state.Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new StateViewModel()
            {
                id = objcategory.id,
                Name = objcategory.Name,
                countryid  = objcategory.countryid,
                isactive = objcategory.isactive,
                isdeleted = objcategory.isdeleted

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.state.Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.Name = model.Name;
                storeobj.countryid = model.countryid;


                _unitofWork.state.Update(storeobj);
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
        public IActionResult GetALL(int countryid)
        {
            var obj = _unitofWork.state.GetAll().Where(x => x.isdeleted == false&&x.countryid == countryid);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj1 = _unitofWork.city.GetAll().Where(x => x.stateid == id && x.isdeleted == false).ToList();
            if (obj1 == null || obj1.Count == 0)
            {
                var obj = _unitofWork.state.Get(id);
                if (obj == null)
                {
                    return Json(new { success = false, message = "Error while deleteing" });
                }
                obj.isdeleted = true;

                _unitofWork.state.Update(obj);
                _unitofWork.Save();
                return Json(new { success = true, message = "Delete Successfuly" });
            }
            else
            {

                return Json(new { success = false, message = "Already City added in this State" });

            }


        }
        #endregion
    }
}
