using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
   public  interface IorderstatusRepository : IRepository<orderstatus>
    {
        void Update(orderstatus  orderstatus);
    }
}
