using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
       
        public string FirstName { get; set; }

        
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

       
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}