using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models
{
   public  class Category
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        public string img { get; set; }


        public string shortdesc { get; set; }
        public string longdescp { get; set; }

        public int seqno { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
