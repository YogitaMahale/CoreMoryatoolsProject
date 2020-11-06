using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using CoreMoryatools.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreMoryatools.Controllers//CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public CategoryController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            return View();
        }





        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }
            category = _unitofWork.category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return View(category);
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.id==0)
                {
                    _unitofWork.category.Add(category);
                   
                }
                else
                {
                    _unitofWork.category.Update(category);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }

        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {
            var obj = _unitofWork.category.GetAll();
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitofWork.category.Get(id);
            if(obj==null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }
            _unitofWork.category.Remove(obj);
            _unitofWork.Save();
            return Json(new { success = true , message = "Delete Successfuly" });
        }
        #endregion
    }
}