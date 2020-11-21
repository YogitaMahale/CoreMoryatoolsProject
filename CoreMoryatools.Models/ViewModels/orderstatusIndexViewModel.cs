using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public  class orderstatusIndexViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Type")]
        public string type { get; set; }
        [Display(Name = "Notification Message")]
        public string NotificationMsg { get; set; }

 
        public Boolean isdeleted { get; set; }
    }
}
