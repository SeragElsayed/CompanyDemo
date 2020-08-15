using EmployeeAPI.Models;
using EmployeeAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.DAL.IManager
{
    public interface IDepartmentManager:IGenericManager<DepartmentViewModel,Department>
    {
    }
}