
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
  public class cityRepository : Repository<city>,IcityRepository 
    {
        private readonly ApplicationDbContext _db;
      
        public cityRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(city city)
        {
            var obj = _db.city.FirstOrDefault(s => s.id  == city.id);
            if(obj!=null)
            {
                obj.Name = city.Name;
                obj.stateid = city.stateid; 
                
                obj.isactive = city.isactive;
                obj.isdeleted = city.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
