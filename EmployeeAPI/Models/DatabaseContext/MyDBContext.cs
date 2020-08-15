namespace EmployeeAPI.Models.DatabaseContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDBContext : DbContext
    {
        
        public MyDBContext()
            : base("name=MyDBContext")
        {
           // Database.SetInitializer(new MyDBInitializer());
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }

  
}