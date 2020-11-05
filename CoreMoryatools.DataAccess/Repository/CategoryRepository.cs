
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
  public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
      
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var obj = _db.Category.FirstOrDefault(s => s.id  == category.id);
            if(obj!=null)
            {
                obj.Name = category.Name;
                obj.img = category.img; 
                obj.shortdesc  = category.shortdesc;

                obj.longdescp  = category.longdescp;
                obj.seqno = category.seqno;
                obj.field1 = category.field1;
                obj.field2 = category.field2;
                obj.isactive = category.isactive;
                obj.isdeleted = category.isdeleted;

                //_db.SaveChanges();
            }

        }
    }
}
