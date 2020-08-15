using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

       // [RegularExpression("@^01[0-2]{1}[0-9]{8}")]
        [Phone]
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}