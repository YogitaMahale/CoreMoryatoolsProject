using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMoryatools.Models
{
   public class state
    {
        public int id { get; set; }

        public int countryid { get; set; }
        [ForeignKey("countryid")]
        public country country { get; set; }


        

        [Required]
        public string Name { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
         
    }
}
