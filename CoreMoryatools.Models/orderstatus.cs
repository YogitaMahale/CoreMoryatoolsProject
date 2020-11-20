using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models
{
 public  class orderstatus
    {
        public int id { get; set; }
        [Required]
        public string type { get; set; }
        public string NotificationMsg { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        
    }
}
