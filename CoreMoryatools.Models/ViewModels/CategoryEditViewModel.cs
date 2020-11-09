using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
  public   class CategoryEditViewModel
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

       
    }
}
