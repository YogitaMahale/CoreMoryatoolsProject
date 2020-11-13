using CoreMoryatools .DataAccess.Data;
using CoreMoryatools.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository
{
   public  class UnitofWork:IUnitofWork
    {
        private readonly ApplicationDbContext _db;
        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            product = new productRepository(_db);
            sp_call = new SP_CALL(_db);
            //coverType = new CoverTypeRepository(_db);
            //product = new ProductRepository(_db);
            //company = new companyRepository(_db);
            applicationUser = new ApplicationUserRepository(_db);
            country  = new countryRepository(_db);
            state   = new stateRepository(_db);
            city = new cityRepository(_db);
        }
        public IApplicationUserRepository applicationUser  { get; private set; }
        public ICategoryRepository category { get; private set; }
        public IproductRepository product { get; private set; }
        //public ICoverTypeRepository coverType { get; private set; }

        //public IProductRepository product { get; private set; }
        public ISP_CALL sp_call { get; private set; }
        //public IcompanyRepository company { get; private set; }

        public IcountryRepository country { get; private set; }
        public IstateRepository  state { get; private set; }
        public IcityRepository  city{ get; private set; }

        //public IshoppingCartsRepository shoppingCarts => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
