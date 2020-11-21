using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMoryatools.Models.ViewModels
{
   public  class bankmasterIndexViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Bank Name")]
        public string bankname { get; set; }
        [Display(Name = "Bank IFSC Code")]
        public string bankifsccode { get; set; }

        [Display(Name = "Branch")]
        public string bankbranch { get; set; }
        [Display(Name = "Account No")]
        public string accountno { get; set; }
        [Display(Name = "Account Holder Name")]

        public string accountholdername { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
