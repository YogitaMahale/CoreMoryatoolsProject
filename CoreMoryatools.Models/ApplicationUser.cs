//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace CoreMoryatools.Models
{
 public  class ApplicationUser : IdentityUser
    {

        //           whatappno, email, gstno, address1, address2, city, state,  isactive, 
        //isdeleted,  deviceid,  latitude, longitude,  
        // usertype, Img,  FK_agentId, logincount,logindate
        [Required(ErrorMessage = "Name is Required")]
        
        public string name { get; set; }       
        public string whatappno { get; set; }  
        public string gstno { get; set; }  
        public string address1 { get; set; }

        public string address2 { get; set; }
        public int?  cityid { get; set; }
       

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string deviceid { get; set; }

        public string usertype { get; set; }
        public string Img { get; set; }
        public int FK_agentId { get; set; } = 0;
        public DateTime logindate { get; set; }

        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
