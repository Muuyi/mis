using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public DepartmentsController(AuthenticationContext context) => _context = context;
      //GET             api/departments
      [HttpGet]
      public ActionResult<IEnumerable<Departments>> GetDepartments()
      {
          return _context.Departments;
      } 
      //GET INDIVIDUAL CLIENTS      api/departments/id
      [HttpGet("{id}")] 
      public ActionResult<Departments> GetIndividualClient(int id)
      {
          var department = _context.Departments.Find(id);
          if(department == null)
          {
              return NotFound();
          }
          return department;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Departments>> PostDepartments(Departments department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return CreatedAtAction("GetDepartments", new Departments{Id=department.Id},department);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutDepartment(int id, Departments department)
        {
            if(id != department.Id)
            {
                return BadRequest();
            }
            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE DEPARTMENTS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Departments> DeleteDepartments(int id)
        {
            var department = _context.Departments.Find(id);
            if(department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return department;
        }
    }
}