namespace EmployeeAPI.Migrations
{
    using EmployeeAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeAPI.Models.DatabaseContext.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(EmployeeAPI.Models.DatabaseContext.MyDBContext context)
        {
            //IList<Department> SeedDepartment = new List<Department>();

            //SeedDepartment.Add(new Department() { DepartmentName = "HR" });
            //SeedDepartment.Add(new Department() { DepartmentName = "IT" });
            ////SeedDepartment.Add(new Department() { DepartmentName = "Sales" });
            ////SeedDepartment.Add(new Department() { DepartmentName = "Planning" });
            ////SeedDepartment.Add(new Department() { DepartmentName = "WareHouses" });
            

            //context.Departments.AddRange(SeedDepartment);

            //IList<Employee> SeedEmployees = new List<Employee>();

            //SeedEmployees.Add(new Employee() {FirstName="Ahmed",LastName="Ali",PhoneNumber="01234567890",BirthDate=DateTime.Now,DepartmentId=1 });
            //SeedEmployees.Add(new Employee() {FirstName="Mohamed",LastName="Mohsen",PhoneNumber="01234567890",BirthDate=DateTime.Now,DepartmentId=1 });
            //SeedEmployees.Add(new Employee() {FirstName="Somya",LastName="Ashraf",PhoneNumber="01234567890",BirthDate=DateTime.Now,DepartmentId=2 });
            //SeedEmployees.Add(new Employee() {FirstName="Maha",LastName="Emad",PhoneNumber="01234567890",BirthDate=DateTime.Now,DepartmentId=2 });

            //context.Employees.AddRange(SeedEmployees);
           
        }
    }
}
