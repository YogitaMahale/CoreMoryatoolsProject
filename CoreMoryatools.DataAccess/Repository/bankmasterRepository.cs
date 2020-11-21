
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
  public class bankmasterRepository : Repository<bankmaster>,IbankmasterRepository
    {
        private readonly ApplicationDbContext _db;
      
        public bankmasterRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(bankmaster country)
        {
            var obj = _db.bankmaster.FirstOrDefault(s => s.id  == country.id);
            if(obj!=null)
            {
                obj.bankname = country.bankname;
                obj.bankifsccode = country.bankifsccode;
                obj.isactive = country.isactive;
                obj.isdeleted = country.isdeleted;
                obj.bankbranch = country.bankbranch;
                obj.accountno = country.accountno;
                obj.accountholdername = country.accountholdername;
                obj.isdeleted = country.isdeleted;

             
                //_db.SaveChanges();
            }

        }
    }
}
