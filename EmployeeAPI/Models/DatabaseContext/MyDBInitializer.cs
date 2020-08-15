using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models.DatabaseContext
{
    public class MyDBInitializer : DropCreateDatabaseAlways<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            IList<Department> SeedDepartment = new List<Department>();

            SeedDepartment.Add(new Department() { DepartmentName = "HR" });
            SeedDepartment.Add(new Department() { DepartmentName = "IT" });
            //SeedDepartment.Add(new Department() { DepartmentName = "Sales" });
            //SeedDepartment.Add(new Department() { DepartmentName = "Planning" });
            //SeedDepartment.Add(new Department() { DepartmentName = "WareHouses" });


            context.Departments.AddRange(SeedDepartment);

            IList<Employee> SeedEmployees = new List<Employee>();

            SeedEmployees.Add(new Employee() { FirstName = "Ahmed", LastName = "Ali", PhoneNumber = "01234567890", BirthDate = DateTime.Now, DepartmentId = 1 });
            SeedEmployees.Add(new Employee() { FirstName = "Mohamed", LastName = "Mohsen", PhoneNumber = "01234567890", BirthDate = DateTime.Now, DepartmentId = 1 });
            SeedEmployees.Add(new Employee() { FirstName = "Somya", LastName = "Ashraf", PhoneNumber = "01234567890", BirthDate = DateTime.Now, DepartmentId = 2 });
            SeedEmployees.Add(new Employee() { FirstName = "Maha", LastName = "Emad", PhoneNumber = "01234567890", BirthDate = DateTime.Now, DepartmentId = 2 });

            context.Employees.AddRange(SeedEmployees);

            base.Seed(context);
        }
    }
}