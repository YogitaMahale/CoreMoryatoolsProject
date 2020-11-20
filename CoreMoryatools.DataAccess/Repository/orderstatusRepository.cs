
using CoreMoryatools.DataAccess.Data;
using CoreMoryatools.DataAccess.Repository;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository
{
  public class orderstatusRepository : Repository<orderstatus>,IorderstatusRepository
    {
        private readonly ApplicationDbContext _db;
      
        public orderstatusRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(orderstatus category)
        {
            var obj = _db.orderstatus.FirstOrDefault(s => s.id  == category.id);
            if(obj!=null)
            {
                obj.type = category.type;
                obj.NotificationMsg = category.NotificationMsg; 
                
                obj.isdeleted = category.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
