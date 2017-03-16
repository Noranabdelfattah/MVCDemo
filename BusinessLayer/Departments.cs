using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BusinessLayer
{ //[Table("Departments")]
    public class Departments
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set;  }
    }
}