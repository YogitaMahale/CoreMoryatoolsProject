using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public  class ProductCreateViewModel
    {
         
        public int Id { get; set; }
        [Required]
        [Display(Name = "Select Category")]
        public int cid { get; set; }




        [Required]
        [Display(Name = "Select Name")]
        public string productname { get; set; }
         
        [Display(Name = "Select Photo")]
        public IFormFile mainimage { get; set; }
        
        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; }
       
        [Display(Name = "Product SKU")]
        public string sku { get; set; }
         
        [Display(Name = "Customer Price")]
        public decimal customerprice { get; set; }
        [Display(Name = "Dealer Price")]
        public decimal dealerprice { get; set; }
        [Display(Name = "Wholesale Price")]
        public decimal wholesaleprice { get; set; }
        [Display(Name = "Super Wholesale Price")]
        public decimal superwholesaleprice { get; set; }
        [Display(Name = "Product Discount Price")]
        public decimal discountprice { get; set; }


        [Display(Name = "Short Description")]
        public string shortdescp { get; set; }
        [Display(Name = "Long Description")]
        public string longdescp { get; set; }

        [Display(Name = "Product GST in %")]
        public decimal gst { get; set; }


        [Display(Name = "Puchase( Landing ) Price")]
        public decimal LandingPrice { get; set; }


        [Display(Name = "Stock Alert Quantites")]
        public int alertquantites { get; set; }
        [Display(Name = "Stock Quantites")]
        public int quantites { get; set; }
        [Display(Name = "Real Stock")]
        public int RealStock { get; set; }
        [Display(Name = "YouTube Video 1")]
        public string video1 { get; set; }
        [Display(Name = "YouTube Video 2")]
        public string video2 { get; set; }
        [Display(Name = "YouTube Video 3")]
        public string video3 { get; set; }
        [Display(Name = "YouTube Video 4")]
        public string video4 { get; set; }
        [Display(Name = "YouTube Video Name 1")]
        public string video_name_1 { get; set; }
        [Display(Name = "YouTube Video Name 2")]
        public string video_name_2 { get; set; }
        [Display(Name = "YouTube Video Name 3")]
        public string video_name_3 { get; set; }
        [Display(Name = "YouTube Video Name 4")]
        public string video_name_4 { get; set; }
        [Display(Name = "Create Date")]

        public DateTime createddate { get; set; }
        public DateTime modifieddate { get; set; }
        [Display(Name = "Stock")]
        public Boolean isstock { get; set; }
        [Display(Name = "Active")]
        public Boolean isactive { get; set; }

        public Boolean isdelete { get; set; }
        [Display(Name = "HotProduct")]
        public Boolean isHotproduct { get; set; }
        [Display(Name = "NewArrival")]
        public Boolean isNewArrivalProduct { get; set; }
    }
}
