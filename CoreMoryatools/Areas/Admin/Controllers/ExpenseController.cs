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
    public class ExpenseController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;
        public ExpenseController(IUnitofWork unitofWork )
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
          
            var model = new ExpenseIndexViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var objcategory = new Expense 
                {
                    id = model.id
                    ,
                    Name  = model.Name
                   
                   ,
                    isdeleted = false
                    ,
                    isactive = false 

                };
               
                _unitofWork.expenses.Add(objcategory);
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
           
            var objcategory = _unitofWork.expenses.Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new ExpenseIndexViewModel()
            {
                id = objcategory.id,
                Name = objcategory.Name,
                
                isactive=objcategory.isactive,
                isdeleted   = objcategory.isdeleted

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExpenseIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.expenses.Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.Name = model.Name;
                
            
                _unitofWork.expenses.Update(storeobj);
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
            var obj = _unitofWork.expenses.GetAll().Where(x=>x.isdeleted==false);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
             
                var obj = _unitofWork.expenses.Get(id);
                if (obj == null)
                {
                    return Json(new { success = false, message = "Error while deleteing" });
                }
                obj.isdeleted = true;

                _unitofWork.expenses.Update(obj);
                _unitofWork.Save();
                return Json(new { success = true, message = "Delete Successfuly" });

           


          
        }
        #endregion
    }
}