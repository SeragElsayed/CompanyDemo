using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}