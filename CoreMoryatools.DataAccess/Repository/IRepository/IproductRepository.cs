using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
  public   interface IproductRepository : IRepository<product>
    {
        void Update(product product);
    }
}
