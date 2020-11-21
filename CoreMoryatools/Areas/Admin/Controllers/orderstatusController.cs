﻿using System;
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
    public class orderstatusController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;
        public orderstatusController(IUnitofWork unitofWork )
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
          
            var model = new orderstatusIndexViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(orderstatusIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var objcategory = new orderstatus  
                {
                    id = model.id
                    ,
                    type   = model.type 
                    , NotificationMsg =model.NotificationMsg
                    
                   ,
                    isdeleted = false
                   
                };
               
                _unitofWork.orderstatuss.Add(objcategory);
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
           
            var objcategory = _unitofWork.orderstatuss  .Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new orderstatusIndexViewModel()
            {
                id = objcategory.id,
               
                type   = objcategory.type,
                NotificationMsg=objcategory.NotificationMsg,
                isdeleted   = objcategory.isdeleted

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(orderstatusIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.orderstatuss .Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.NotificationMsg = model.NotificationMsg;
                storeobj.type   = model.type ;
                 
            
                _unitofWork.orderstatuss.Update(storeobj);
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
            var obj = _unitofWork.orderstatuss.GetAll().Where(x=>x.isdeleted==false);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
             
                var obj = _unitofWork.orderstatuss .Get(id);
                if (obj == null)
                {
                    return Json(new { success = false, message = "Error while deleteing" });
                }
                obj.isdeleted = true;

                _unitofWork.orderstatuss.Update(obj);
                _unitofWork.Save();
                return Json(new { success = true, message = "Delete Successfuly" });

            


          
        }
        #endregion
    }
}