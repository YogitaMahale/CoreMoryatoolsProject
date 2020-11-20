using System;
using System.Collections.Generic;
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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
            ViewBag.categorylist = _unitofWork.category.GetAll().ToList();
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
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                 
                int maxseqno = _unitofWork.product.GetAll().Where(x => x.isdelete == false && x.cid == model.cid).Select(p => p.seqno ).DefaultIfEmpty(0).Max();
                maxseqno++;
                int t = 0;
                var objcategory = new product
                {
                    Id = model.Id
      ,
                    cid = model.cid
      ,
                    productname = model.productname
       
      ,
                    HSNCode = model.HSNCode
      ,
                    sku = model.sku
      ,
                    customerprice = model.customerprice
      ,
                    dealerprice = model.dealerprice
      ,
                    wholesaleprice = model.wholesaleprice
      ,
                    superwholesaleprice = model.superwholesaleprice
      ,
                    discountprice = model.discountprice
      ,
                    shortdescp = model.shortdescp
      ,
                    longdescp = model.longdescp
      ,
                    gst = model.gst
      ,
                    LandingPrice = model.LandingPrice
      ,
                    alertquantites = model.alertquantites
      ,
                    quantites = model.quantites
      ,
                    RealStock = model.RealStock
      ,
                    seqno = maxseqno
      ,
                    video1 = model.video1
      ,
                    video2 = model.video2
      ,
                    video3 = model.video3
      ,
                    video4 = model.video4
      ,
                    video_name_1 = model.video_name_1
      ,
                    video_name_2 = model.video_name_2
      ,
                    video_name_3 = model.video_name_3
      ,
                    video_name_4 = model.video_name_4
      ,
                    createddate = model.createddate
      ,
                    modifieddate = model.modifieddate
      ,
                    isstock = model.isstock
      ,
                    isactive = model.isactive
      ,
                    isdelete = false 
      ,
                    isHotproduct = model.isHotproduct
      ,
                    isNewArrivalProduct = model.isNewArrivalProduct

                };
                if (model.mainimage  != null && model.mainimage.Length > 0)
                {
                    var uploadDir = @"uploads/Product";
                    var fileName = Path.GetFileNameWithoutExtension(model.mainimage.FileName);
                    var extesion = Path.GetExtension(model.mainimage.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.mainimage.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcategory.mainimage = '/' + uploadDir + '/' + fileName;

                }
                _unitofWork.product.Add(objcategory);
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
            ViewBag.categorylist = _unitofWork.category.GetAll().ToList();
            var model = _unitofWork.product.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            var model1 = new ProductEditViewModel()
            {
                Id = model.Id
      ,
                cid = model.cid
      ,
                productname = model.productname
      //,
      //          mainimage = model.mainimage
      ,
                HSNCode = model.HSNCode 
      ,
                sku = model.sku
      ,
                customerprice = model.customerprice
      ,
                dealerprice = model.dealerprice
      ,
                wholesaleprice = model.wholesaleprice
      ,
                superwholesaleprice = model.superwholesaleprice
      ,
                discountprice = model.discountprice 
      ,
                shortdescp = model.shortdescp 
      ,
                longdescp = model.longdescp 
      ,
                gst = model.gst 
      ,
                LandingPrice = model.LandingPrice 
      ,
                alertquantites = model.alertquantites 
      ,
                quantites = model.quantites 
      ,
                RealStock = model.RealStock 
      
      ,
                video1 = model.video1 
      ,
                video2 = model.video2
      ,
                video3 = model.video3
      ,
                video4 = model.video4
      ,
                video_name_1 = model.video_name_1
      ,
                video_name_2 = model.video_name_2
      ,
                video_name_3 = model.video_name_3
      ,
                video_name_4 = model.video_name_4
      ,
                createddate = model.createddate
      ,
                modifieddate = model.modifieddate
      ,
                isstock = model.isstock
      ,
                isactive = model.isactive
      
      
      ,
                isHotproduct = model.isHotproduct 
      ,
                isNewArrivalProduct = model.isNewArrivalProduct 

            };
            return View(model1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var obj = _unitofWork.product .Get(model.Id);
                if (obj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                obj.Id = model.Id;
                obj.cid = model.cid;
                obj.productname = model.productname;
               
                obj.HSNCode = model.HSNCode;
                obj.sku = model.sku;
                obj.customerprice = model.customerprice;
                obj.dealerprice = model.dealerprice;
                obj.wholesaleprice = model.wholesaleprice;
                obj.superwholesaleprice = model.superwholesaleprice;
                obj.discountprice = model.discountprice;
                obj.shortdescp = model.shortdescp;
                obj.longdescp = model.longdescp;
                obj.gst = model.gst;
                obj.LandingPrice = model.LandingPrice;
                obj.alertquantites = model.alertquantites;
                obj.quantites = model.quantites;
                obj.RealStock = model.RealStock;

                obj.video1 = model.video1;
                obj.video2 = model.video2;
                obj.video3 = model.video3;
                obj.video4 = model.video4;
                obj.video_name_1 = model.video_name_1;
                obj.video_name_2 = model.video_name_2;
                obj.video_name_3 = model.video_name_3;
                obj.video_name_4 = model.video_name_4;
                obj.createddate = model.createddate;
                obj.modifieddate = model.modifieddate;
                obj.isstock = model.isstock;
                obj.isactive = model.isactive;

                obj.isHotproduct = model.isHotproduct;
                obj.isNewArrivalProduct = model.isNewArrivalProduct;
                if (model.mainimage != null && model.mainimage.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.mainimage.FileName);
                    var extesion = Path.GetExtension(model.mainimage.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.mainimage.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj.mainimage = '/' + uploadDir + '/' + fileName;

                }
                _unitofWork.product.Update(obj);
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
        public IActionResult GetALL(int categoryid)
        {
            var obj = _unitofWork.product.GetAll().Where(x => x.isdelete == false&&x.cid==categoryid);
            return Json(new { data = obj });
        }
        //public IActionResult GetALL()
        //{
        //    var obj = _unitofWork.product.GetAll().Where(x => x.isdelete == false);
        //    return Json(new { data = obj });
        //}

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