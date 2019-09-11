using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
      private readonly AuthenticationContext _context;
      public EmployeesController(AuthenticationContext context) => _context = context;
      //GET             api/departments
    [HttpGet]
    public JsonResult GetAllEmployee(){
        var employees=  _context.Employees.Include(c => c.Department).ToList();
        return  Json(employees);
    }
    // private Task<List<Employees>> GetAllEmployee(){
    //     var employees = _context.Employees.Include(c => c.Department);
    //     return employees.ToListAsync();
    // }
    // public ActionResult<Employees> GetEmployees()
    // {
    //     var employees =  _context.Employees.Include(c => c.Department);
    //     return  employees;
    // }
    //   public ActionResult<IEnumerable<Employees>> GetEmployees()
    //   {
    //       var employees = _context.Employees;
    //       return _context.Employees;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/departments/id
      [HttpGet("{id}")] 
      public ActionResult<Employee> GetIndividualEmployee(int id)
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
        public ActionResult<IEnumerable<Employee>> PostEmployees(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction("GetEmployees", new Employee{EmployeeId=employee.EmployeeId},employee);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Employee employee)
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE DEPARTMENTS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployees(int id)
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