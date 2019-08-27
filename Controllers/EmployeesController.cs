using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public EmployeesController(AuthenticationContext context) => _context = context;
      //GET             api/departments
      [HttpGet]
      public ActionResult<IEnumerable<Employees>> GetEmployees()
      {
          return _context.Employees;
      } 
      //GET INDIVIDUAL CLIENTS      api/departments/id
      [HttpGet("{id}")] 
      public ActionResult<Employees> GetIndividualEmployee(int id)
      {
          var employee = _context.Employees.Find(id);
          if(employee == null)
          {
              return NotFound();
          }
          return employee;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Employees>> PostEmployees(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction("GetEmployees", new Employees{Id=employee.Id},employee);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Employees employee)
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE DEPARTMENTS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Employees> DeleteEmployees(int id)
        {
            var employee = _context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}