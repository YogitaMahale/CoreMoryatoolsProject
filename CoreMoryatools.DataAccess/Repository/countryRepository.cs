
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
  public class countryRepository : Repository<country>,IcountryRepository
    {
        private readonly ApplicationDbContext _db;
      
        public countryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(country country)
        {
            var obj = _db.country.FirstOrDefault(s => s.id  == country.id);
            if(obj!=null)
            {
                obj.Name = country.Name;
                obj.countrycode = country.countrycode;
                obj.isactive = country.isactive;
                obj.isdeleted = country.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
