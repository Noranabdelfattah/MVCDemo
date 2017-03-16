using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    // [Table("tblEmployee")]
    public class Employee
    {
        public int EmployeeId { set; get; }
       
        public string Name { set; get; }
        [Required]
        public string Gender { set; get; }
        [Required]
        public string City { set; get; }
        [Required]
        public int DepartementId { set; get; }

    }
}