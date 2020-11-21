using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
   public  interface IbankmasterRepository : IRepository<bankmaster>
    {
        void Update(bankmaster bankmaster);
    }
}
