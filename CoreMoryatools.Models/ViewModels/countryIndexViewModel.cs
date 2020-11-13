using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public   class countryIndexViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Counrty Code")]
        public string countrycode { get; set; }


         
        public Boolean isdeleted { get; set; }
       
        public Boolean isactive { get; set; }
    }
}
