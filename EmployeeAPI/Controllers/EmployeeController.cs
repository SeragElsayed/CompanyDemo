using EmployeeAPI.DAL;
using EmployeeAPI.Models;
using EmployeeAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeManager EmployeeManager;
        public EmployeeController()
        {
            EmployeeManager = new EmployeeManager();
        }
        // GET: api/Employee
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var AllEmployees = await EmployeeManager.GetAll();
                return Ok(AllEmployees);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // GET: api/Employee/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var Employee = await EmployeeManager.GetById(id);

                if (Employee == null)
                    return NotFound();

                return Ok(Employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // POST: api/Employee
        public async Task<IHttpActionResult> Post([FromBody]Employee NewEmployee)
        {
            try
            {

                if (ModelState.IsValid == false)
                    return BadRequest();
                var AddedEmployee = await EmployeeManager.Add(NewEmployee);
                return Created<EmployeeViewModel>("DB", AddedEmployee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // PUT: api/Employee/5
        public async Task<IHttpActionResult> Put( [FromBody]Employee ToEditedEmployee)
        {
            try
            {

                if (ModelState.IsValid == false || ToEditedEmployee.EmployeeId <= 0)
                    return BadRequest();

                var EditedEmployee = await EmployeeManager.Edit(ToEditedEmployee);
                return Ok(EditedEmployee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return InternalServerError();
            }
        }

        // DELETE: api/Employee/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var EmployeeToBeDeleted =await EmployeeManager.GetById(id);

                if (EmployeeToBeDeleted == null)
                    return NotFound();

                await EmployeeManager.Delete(id);
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
