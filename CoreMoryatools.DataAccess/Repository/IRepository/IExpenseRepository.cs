using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMoryatools.DataAccess.Repository.IRepository
{
   public  interface IExpenseRepository : IRepository<Expense>
    {
        void Update(Expense expense);
    }
}
