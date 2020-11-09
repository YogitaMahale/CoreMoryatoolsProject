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
   // [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUnitofWork _unitofWork;
        public CategoryController(IUnitofWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            var model = new CategoryCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var objcategory = new Category
                {
                    id = model.id
                    ,
                    Name  = model.Name
                    , shortdesc=model.shortdesc
                    ,
                    longdescp  = model.longdescp
                   ,
                    isdeleted = false
                    ,
                    isactive = false 

                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/categoryimg";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcategory.img = '/' + uploadDir + '/' + fileName;

                }
                _unitofWork.category.Add(objcategory);
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
           
            var objcategory = _unitofWork.category.Get(id);
            if (objcategory == null)
            {
                return NotFound();
            }
            var model = new CategoryEditViewModel()
            {
                id = objcategory.id,
                Name = objcategory.Name,
                shortdesc  = objcategory.shortdesc,
                longdescp  = objcategory.longdescp

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _unitofWork.category.Get(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.Name = model.Name;
                storeobj.shortdesc = model.shortdesc;
                storeobj.longdescp  = model.longdescp;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/categoryimg";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.img = '/' + uploadDir + '/' + fileName;

                }
                _unitofWork.category.Update(storeobj);
                _unitofWork.Save();
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

         

        /*

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
        */
        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {
            var obj = _unitofWork.category.GetAll().Where(x=>x.isdeleted==false);
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
            obj.isdeleted = true;

            _unitofWork.category.Update(obj);
            _unitofWork.Save();
            return Json(new { success = true , message = "Delete Successfuly" });
        }
        #endregion
    }
}