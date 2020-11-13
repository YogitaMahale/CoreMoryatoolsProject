using CoreMoryatools.DataAccess.Data;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository
{
  public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
      
        public ApplicationUserRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        
    }
}
