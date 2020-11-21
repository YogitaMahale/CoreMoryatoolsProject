using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
   public  interface IUnitofWork:IDisposable
    {
       IApplicationUserRepository applicationUser { get; }
        ICategoryRepository category { get; }
        IproductRepository product { get; }
        // ICoverTypeRepository coverType { get; }
        // IProductRepository product { get; }
        ISP_CALL sp_call { get; }
        IcountryRepository country { get; }

        IstateRepository state  { get; }
        IcityRepository city { get; }

        IorderstatusRepository  orderstatuss { get; }
        IExpenseRepository expenses { get; }
        IbankmasterRepository bankmaster { get; }
        // IOrderDetailsRepository orderDetailsRepository { get; }
        void Save();
    }
}
