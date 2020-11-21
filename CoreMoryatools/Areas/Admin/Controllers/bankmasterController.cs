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

namespace CoreMoryatools.Controllers//CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Authorize(Roles =SD.Role_Admin)]
    public class bankmasterController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;
        public bankmasterController(IUnitofWork unitofWork )
        {
            _unitofWork = unitofWork;
             
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            var model = new bankmasterIndexViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(bankmasterIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var objcategory = new bankmaster 
                {
                     
                    id = model.id,
                    bankname = model.bankname,
                    bankifsccode = model.bankifsccode,
                    bankbranch = model.bankbranch,
                    accountno = model.accountno,
                    accountholdername = model.accountholdername,
                    isdeleted = false,
                    isactive = false 
                };
               
                _unitofWork.bankmaster.Add(objcategory);
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
           
            var objcategory = _unitofWork.bankmaster.Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new bankmasterIndexViewModel()
            {
                id = objcategory.id,
                bankname = objcategory.bankname,
                bankifsccode = objcategory.bankifsccode,
                bankbranch = objcategory.bankbranch,
                accountno = objcategory.accountno,
                accountholdername = objcategory.accountholdername,
                isdeleted = objcategory.isdeleted,
                isactive = objcategory.isactive
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(bankmasterIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.bankmaster.Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.bankname = model.bankname;
                storeobj.bankifsccode = model.bankifsccode;
                storeobj.bankbranch = model.bankbranch;
                storeobj.accountno = model.accountno;
                storeobj.accountholdername = model.accountholdername;

                 
                _unitofWork.bankmaster .Update(storeobj);
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
        public IActionResult GetALL()
        {
            var obj = _unitofWork.bankmaster.GetAll().Where(x=>x.isdeleted==false);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
             
                var obj = _unitofWork.bankmaster.Get(id);
                if (obj == null)
                {
                    return Json(new { success = false, message = "Error while deleteing" });
                }
                obj.isdeleted = true;

                _unitofWork.bankmaster.Update(obj);
                _unitofWork.Save();
                return Json(new { success = true, message = "Delete Successfuly" });

             


          
        }
        #endregion
    }
}