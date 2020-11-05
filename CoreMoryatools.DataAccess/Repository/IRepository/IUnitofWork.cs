using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
   public  interface IUnitofWork:IDisposable
    {
      //  IApplicationUserRepository applicationUser { get; }
        ICategoryRepository category { get; }
       // ICoverTypeRepository coverType { get; }
       // IProductRepository product { get; }
        ISP_CALL sp_call { get; }
      //  IcompanyRepository company { get; }

       // IshoppingCartsRepository shoppingCartsRepository { get; }
       // IorderHeadersRepository orderHeadersRepository { get; }
       // IOrderDetailsRepository orderDetailsRepository { get; }
        void Save();
    }
}
