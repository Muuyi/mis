using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public TasksController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public ActionResult<IEnumerable<Tasks>> GetRecords()
      {
          return _context.Tasks;
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Tasks> GetIndividualRecord(int id)
      {
          var record = _context.Tasks.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Tasks>> PostRecord(Tasks record)
        {
            _context.Tasks.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Tasks{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Tasks record)
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
        public ActionResult<Tasks> DeleteRecord(int id)
        {
            var record = _context.Tasks.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}