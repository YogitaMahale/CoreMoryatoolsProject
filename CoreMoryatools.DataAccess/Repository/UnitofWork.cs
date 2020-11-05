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
            sp_call = new SP_CALL(_db);
            //coverType = new CoverTypeRepository(_db);
            //product = new ProductRepository(_db);
            //company = new companyRepository(_db);
            //applicationUser = new ApplicationUserRepository(_db);
            //shoppingCartsRepository = new shoppingCartsRepository(_db);
            //orderDetailsRepository = new OrderDetailsRepository(_db);
            //orderHeadersRepository = new orderHeadersRepository(_db);
        }
       // public IApplicationUserRepository applicationUser  { get; private set; }
        public ICategoryRepository category { get; private set; }

        //public ICoverTypeRepository coverType { get; private set; }

        //public IProductRepository product { get; private set; }
        public ISP_CALL sp_call { get; private set; }
        //public IcompanyRepository company { get; private set; }

        //public IshoppingCartsRepository shoppingCartsRepository { get; private set; }
        //public IorderHeadersRepository orderHeadersRepository { get; private set; }
        //public IOrderDetailsRepository orderDetailsRepository { get; private set; }

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
