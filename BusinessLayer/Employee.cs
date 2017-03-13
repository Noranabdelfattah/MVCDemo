using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
   // [Table("tblEmployee")]
    public class Employee
    {
    
        public string EmployeeId { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string City { set; get; }
  
        public int DepartementId { set; get; }
       
    }
}