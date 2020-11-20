
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
  public class ExpenseRepository : Repository<Expense>,IExpenseRepository
    {
        private readonly ApplicationDbContext _db;
      
        public ExpenseRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Expense expense)
        {
            var obj = _db.Expense.FirstOrDefault(s => s.id  == expense.id);
            if(obj!=null)
            {
                obj.Name = expense.Name;
               
                obj.isactive = expense.isactive;
                obj.isdeleted = expense.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
