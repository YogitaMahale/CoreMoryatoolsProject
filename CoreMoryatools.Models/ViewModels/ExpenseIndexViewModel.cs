using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public   class ExpenseIndexViewModel
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }


         
        public Boolean isdeleted { get; set; }
        
        public Boolean isactive { get; set; }
    }
}
