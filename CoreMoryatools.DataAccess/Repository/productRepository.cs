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

        public void Update(product category)
        {
            var obj = _db.product.FirstOrDefault(s => s.Id == category.Id);
            if (obj != null)
            {
                
                obj.cid = category.cid;
                     obj.productname = category.productname;
                     obj.mainimage = category.mainimage;
                     obj.HSNCode = category.HSNCode;
                     obj.sku = category.sku;
                     obj.customerprice = category.customerprice;
                     obj.dealerprice = category.dealerprice;
                     obj.wholesaleprice = category.wholesaleprice;
                     obj.superwholesaleprice = category.superwholesaleprice;
                     obj.discountprice = category.discountprice;
                     obj.shortdescp = category.shortdescp;
                     obj.longdescp = category.longdescp;
                     obj.gst = category.gst;
                     obj.LandingPrice = category.LandingPrice;
                     obj.alertquantites = category.alertquantites;
                     obj.quantites = category.quantites;
                     obj.RealStock = category.RealStock ;
                     obj.seqno = category.seqno;
                     obj.video1 = category.video1;
                     obj.video2 = category.video2;
                     obj.video3 = category.video3;
                     obj.video4 = category.video4;
                    obj.video_name_1 = category.video_name_1;
                     obj.video_name_2 = category.video_name_2;
                     obj.video_name_3 = category.video_name_3;
                     obj.video_name_4 = category.video_name_4;
                     obj.createddate = category.createddate;
                     obj.modifieddate = category.modifieddate;
                     obj.isstock = category.isstock;
                     obj.isactive = category.isactive;
                     obj.isdelete = category.isdelete;
                     obj.isHotproduct = category.isHotproduct;
                    obj.isNewArrivalProduct = category.isNewArrivalProduct;
                _db.SaveChanges();
            }

        }
    }
}
