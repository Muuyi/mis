using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsProgressController : Controller
    {
      private readonly AuthenticationContext _context;
      public ProjectsProgressController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public JsonResult GetAllProjectsProgress(){
            var projects =  _context.Projects.Include(c => c.ProjectsProgress).ThenInclude(p => p.ApplicationUser).ToList();
            return  Json(projects);
        }
    //   public ActionResult<IEnumerable<ProjectsProgress>> GetRecords()
    //   {
    //       return _context.ProjectsProgress;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<ProjectsProgress> GetIndividualRecord(int id)
      {
          var record = _context.ProjectsProgress.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<ProjectsProgress>> PostRecord(ProjectsProgress record)
        {
            _context.ProjectsProgress.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new ProjectsProgress{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, ProjectsProgress record)
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
        public ActionResult<ProjectsProgress> DeleteRecord(int id)
        {
            var record = _context.ProjectsProgress.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.ProjectsProgress.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}