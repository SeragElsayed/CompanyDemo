using EmployeeAPI.DAL;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        DepartmentManager DepartmentManager;
        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
        }
        // GET: api/Department
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var AllDepartments = await DepartmentManager.GetAll();
                return Ok(AllDepartments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // GET: api/Department/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var Department = await DepartmentManager.GetById(id);

                if (Department == null)
                    return NotFound();

                return Ok(Department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // POST: api/Department
        public async Task<IHttpActionResult> Post([FromBody]Department NewDepartment)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest();
                var AddedDepartment = await DepartmentManager.Add(NewDepartment);
                return Created<Department>("DB", NewDepartment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // PUT: api/Department/5
        public async Task<IHttpActionResult> Put([FromBody]Department ToEditedDepartment)
        {
            try
            {

                if (ModelState.IsValid == false || ToEditedDepartment.DepartmentId <= 0)
                    return BadRequest();

                var EditedDepartment = await DepartmentManager.Edit(ToEditedDepartment);
                return Ok(EditedDepartment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // DELETE: api/Department/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var DepartmentToBeDeleted =await DepartmentManager.GetById(id);

                if (DepartmentToBeDeleted == null)
                    return NotFound();

                await DepartmentManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }
    }
}
