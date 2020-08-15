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
    public class DepartmentManager : IDepartmentManager
    {
        MyDBContext DB;
        public DepartmentManager()
        {
            DB = new MyDBContext();
        }
       
        private DepartmentViewModel DepartmentToDepartmentViewModel(Department department)
        {
            var departmentViewModel = new DepartmentViewModel()
            {
                DepartmentId=department.DepartmentId,
                DepartmentName=department.DepartmentName
            };
            return departmentViewModel;
        }

        public async Task<DepartmentViewModel> Add(Department NewDepartment)
        {
            try
            {

                DB.Departments.Add(NewDepartment);
                await DB.SaveChangesAsync();

                return this.DepartmentToDepartmentViewModel(NewDepartment);
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
                var ToBeDeletedDepartment = await DB.Departments.FindAsync(id);

                if (ToBeDeletedDepartment == null)
                    return;
                DB.Departments.Remove(ToBeDeletedDepartment);
                await DB.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<DepartmentViewModel> Edit(Department EditedDepartment)
        {
            try
            {

                var OldDepartment = await DB.Departments.FindAsync(EditedDepartment.DepartmentId);
                OldDepartment.DepartmentName = EditedDepartment.DepartmentName;
                
                await DB.SaveChangesAsync();
             
                return this.DepartmentToDepartmentViewModel(EditedDepartment);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            try
            {

                var AllDepartments = await DB.Departments.ToListAsync();
                List<DepartmentViewModel> DepartmentList = new List<DepartmentViewModel>();

                foreach (var item in AllDepartments)
                {
                    DepartmentList.Add(this.DepartmentToDepartmentViewModel(item));
                }
                return DepartmentList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<DepartmentViewModel> GetById(int DepartmentId)
        {
            try
            {

                var Department = await DB.Departments.FindAsync(DepartmentId);

                if (Department == null)
                    return null;

               
                return this.DepartmentToDepartmentViewModel(Department);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}