using EmployeeAPI.DAL.IManager;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DatabaseContext;
using EmployeeAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeAPI.DAL
{
    public class EmployeeManager : IEmployeeManager
    {
        MyDBContext DB;
        public EmployeeManager()
        {
            DB = new MyDBContext();
        }
        private  EmployeeViewModel EmployeeToEmployeeViewModel(Employee employee)
        {
            if (employee.Department == null)
                employee.Department =  DB.Departments.Find(employee.DepartmentId);

            var employeeViewModel = new EmployeeViewModel()
            {
                EmployeeId=employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                PhoneNumber = employee.PhoneNumber,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.DepartmentName,
            };
            return employeeViewModel;

        }

        public async Task<EmployeeViewModel> Add(Employee NewEmployee)
        {
            try
            {

                DB.Employees.Add(NewEmployee);
                await DB.SaveChangesAsync();

                return this.EmployeeToEmployeeViewModel(NewEmployee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var ToBeDeletedEmployee = await DB.Employees.FindAsync(id);

                if (ToBeDeletedEmployee == null)
                    return ;
                DB.Employees.Remove(ToBeDeletedEmployee);
                await DB.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<EmployeeViewModel> Edit(Employee EditedEmployee)
        {
            try
            {

                var OldEmployee = await DB.Employees.FindAsync(EditedEmployee.EmployeeId);
                OldEmployee.FirstName = EditedEmployee.FirstName;
                OldEmployee.LastName = EditedEmployee.LastName;
                OldEmployee.BirthDate = EditedEmployee.BirthDate;
                OldEmployee.PhoneNumber = EditedEmployee.PhoneNumber;
                OldEmployee.DepartmentId = EditedEmployee.DepartmentId;
                await DB.SaveChangesAsync();
                return this.EmployeeToEmployeeViewModel(EditedEmployee);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            try
            {

                var AllEmployees = await DB.Employees.ToListAsync();
                List<EmployeeViewModel> EmployeeList = new List<EmployeeViewModel>();

                foreach (var item in AllEmployees)
                {
                    
                    EmployeeList.Add(this.EmployeeToEmployeeViewModel(item));
                }
                return EmployeeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeeViewModel> GetById(int EmployeeId)
        {
            try
            {

                var Employee = await DB.Employees.FindAsync(EmployeeId);

                if (Employee == null)
                    return null;
                
                return this.EmployeeToEmployeeViewModel(Employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}