using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public   class CategoryCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
         
        [Display(Name = "Select Image")]
        public IFormFile img { get; set; }

       
        [Display(Name = "Short Description")]
        public string shortdesc { get; set; }
        
        [Display(Name = "Long Description")]
        public string longdescp { get; set; }

        public int seqno { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }

        
        public Boolean isdeleted { get; set; }
        
        public Boolean isactive { get; set; }
    }
}
