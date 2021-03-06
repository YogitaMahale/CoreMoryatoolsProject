﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreMoryatools.Models
{
    public class city
    {
        public int id { get; set; }

        public int stateid { get; set; }
        [ForeignKey("stateid")]
        public state state { get; set; }



        [Required]
        public string Name { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
