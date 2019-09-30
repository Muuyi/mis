using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
      private readonly AuthenticationContext _context;
      public ProjectsController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
       public JsonResult GetAllProjects(){
            var projects =  _context.Projects.Include(c => c.ApplicationUser).Include(p => p.ProjectsProgress).ToList();
            return  Json(projects);
        }
    //   public ActionResult<IEnumerable<Projects>> GetRecords()
    //   {
    //       return _context.Projects;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Projects> GetIndividualRecord(int id)
      {
          var record = _context.Projects.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Projects>> PostRecord(Projects record)
        {
            _context.Projects.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Projects{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Projects record)
        {
            if(id != record.Id)
            {
                return BadRequest();
            }
            _context.Entry(record).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE RECORDS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Projects> DeleteRecord(int id)
        {
            var record = _context.Projects.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}