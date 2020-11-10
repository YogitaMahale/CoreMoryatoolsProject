using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using CoreMoryatools.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly  IWebHostEnvironment _hostingEnvironment;
        private readonly IUnitofWork _unitofWork;
        public ProductController(IUnitofWork unitofWork, IWebHostEnvironment hostingEnvironment)
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
            ViewBag.categorylist = _unitofWork.category.GetAll().ToList();
            var model = new ProductCreateViewModel();
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
                    Name = model.Name
                    ,
                    shortdesc = model.shortdesc
                    ,
                    longdescp = model.longdescp
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
                shortdesc = objcategory.shortdesc,
                longdescp = objcategory.longdescp

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
                storeobj.longdescp = model.longdescp;
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



      
        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {
            var obj = _unitofWork.product.GetAll().Where(x => x.isdelete == false);
            return Json(new { data = obj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitofWork.product.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }
            obj.isdelete  = true;

            _unitofWork.product .Update(obj);
            _unitofWork.Save();
            return Json(new { success = true, message = "Delete Successfuly" });
        }
        #endregion
    }
}