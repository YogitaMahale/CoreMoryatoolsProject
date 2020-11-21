using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models
{
   public class bankmaster
    {
       // bankid, bankname, bankifsccode, bankbranch, accountno, accountholdername, isactive, isdelete
        public int id { get; set; }
        [Required]
        public string bankname { get; set; }

        public string bankifsccode { get; set; }


        public string bankbranch { get; set; }
        public string accountno { get; set; }

        public string  accountholdername { get; set; }
       

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
