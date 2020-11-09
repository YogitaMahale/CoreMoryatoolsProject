using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreMoryatools.Models
{
  public  class productimages
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int pid { get; set; }
        [ForeignKey("pid")]
        public product product { get; set; }

        [Required]
        public string imagename { get; set; }
       
        public Boolean isdelete { get; set; }
      

    }
}
