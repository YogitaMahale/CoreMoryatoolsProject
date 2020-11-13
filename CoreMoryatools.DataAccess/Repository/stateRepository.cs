
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
  public class stateRepository : Repository<state >,IstateRepository
    {
        private readonly ApplicationDbContext _db;
      
        public stateRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(state  state)
        {
            var obj = _db.state .FirstOrDefault(s => s.id  == state.id);
            if(obj!=null)
            {
                obj.Name = state .Name;
                obj.countryid = state.countryid; 
                
                obj.isactive = state.isactive;
                obj.isdeleted = state.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
