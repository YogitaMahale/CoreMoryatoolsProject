using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public  class cityViewModel
    {
        public int id { get; set; }


        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select State")]
        public int stateid { get; set; }


        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        
        public Boolean isdeleted { get; set; }
        
        public Boolean isactive { get; set; }
    }
}
