using CoreMoryatools.DataAccess.Data;
using CoreMoryatools.DataAccess.Repository.IRepository;
using CoreMoryatools.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CoreMoryatools.DataAccess.Repository
{
   public  class productRepository : Repository<product>, IproductRepository
    {
        private readonly ApplicationDbContext _db;

        public productRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(product product)
        {
            var obj = _db.product.FirstOrDefault(s => s.Id == product.Id);
            if (obj != null)
            {
                //obj.cid = category.Name;
                //obj.img = category.img;
                //obj.shortdesc = category.shortdesc;

                //obj.longdescp = category.longdescp;
                //obj.seqno = category.seqno;
                //obj.field1 = category.field1;
                //obj.field2 = category.field2;
                //obj.isactive = category.isactive;
                //obj.isdeleted = category.isdeleted;



                //obj.cid = category.
                //    , obj.productname = category.
                //    , obj.mainimage = category.
                //    , obj.HSNCode = category.
                //    , obj.sku = category.
                //    , obj.customerprice = category.
                //    , obj.dealerprice = category.
                //    , obj.wholesaleprice = category.
                //    , obj.superwholesaleprice = category.
                //    , obj.discountprice = category.
                //    , obj.shortdescp = category.
                //    , obj.longdescp = category.
                //    , obj.gst = category.
                //    , obj.LandingPrice = category.
                //    , obj.alertquantites = category.
                //    , obj.quantites = category.
                //    , obj.RealStock = category.
                //    , obj.seqno
                //    , obj.video1
                //    , obj.video2
                //    , obj.video3
                //    , obj.video4
                //    ,obj.video_name_1
                //    , obj.video_name_2
                //    , obj.video_name_3
                //    , obj.video_name_4
                //    , obj.createddate
                //    , obj.modifieddate
                //    , obj.isstock
                //    , obj.isactive
                //    , obj.isdelete
                //    , obj.isHotproduct
                //    ,obj.isNewArrivalProduct
                //_db.SaveChanges();
            }

        }
    }
}
