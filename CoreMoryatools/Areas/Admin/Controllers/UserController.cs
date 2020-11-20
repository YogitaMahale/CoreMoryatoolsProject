using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CoreMoryatools.DataAccess;
using CoreMoryatools.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.AspNetCore.Authorization;
using CoreMoryatools.Utility;

namespace CoreMoryatools.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

         

        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {

            //var userList = _db.ApplicationUser.Include(u => u.company).ToList();
            var userList = _db.ApplicationUser.ToList();
            var userRole = _db.UserRoles.ToList();
            var Roles = _db.Roles.ToList();
            foreach(var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = Roles.FirstOrDefault(u => u.Id == roleId).Name;
                //if(user.company==null)
                //{
                //    user.company = new company()
                //    {
                //        Name = ""
                //    };
                //}

            }
            return Json(new { data = userList });
            //var obj = _unitofWork.category.GetAll();
            //return Json(new { data = obj });
        }

       [HttpPost]
       public IActionResult Lockunlock([FromBody] string id)
        {
            var objfromdb = _db.ApplicationUser.FirstOrDefault(u => u.Id == id);
            if(objfromdb==null)
            {
                return Json(new { success = false, message = "error while locking / unlocking" });
            }
            if(objfromdb.LockoutEnd!=null&&objfromdb.LockoutEnd>DateTime.Now)
            {
                objfromdb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objfromdb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true , message = "Operation successful" });
        }
        #endregion
    }
}