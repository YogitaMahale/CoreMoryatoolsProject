using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreMoryatools.Models
{
  public  class product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int cid { get; set; }
        [ForeignKey("cid")]
        public Category category { get; set; }

         

        [Required]
        public string productname { get; set; }
        public string mainimage { get; set; }
        public string HSNCode { get; set; }
        public string sku { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal  customerprice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal  dealerprice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal  wholesaleprice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal superwholesaleprice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal discountprice { get; set; }
        
     
     
        public string shortdescp { get; set; }
        public string longdescp { get; set; }
        
      
      
        [Column(TypeName = "decimal(18, 2)")]
        public decimal  gst { get; set; }
       
      
     
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal  LandingPrice { get; set; }


       
        public int alertquantites { get; set; }
        public int quantites { get; set; }
        public int RealStock { get; set; }
        public int seqno { get; set; }
        public string video1 { get; set; }
        public string video2 { get; set; }
        public string video3 { get; set; }
        public string video4 { get; set; }
        public string video_name_1 { get; set; }
        public string video_name_2 { get; set; }
        public string video_name_3 { get; set; }
        public string video_name_4 { get; set; }

        public DateTime createddate { get; set; }
        public DateTime modifieddate { get; set; }
        public Boolean isstock { get; set; }
        public Boolean isactive { get; set; }
        public Boolean isdelete { get; set; }
        public Boolean isHotproduct { get; set; }

        public Boolean isNewArrivalProduct { get; set; }



    }
}
