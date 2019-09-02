using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksProgressController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public TasksProgressController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public ActionResult<IEnumerable<TasksProgress>> GetRecords()
      {
          return _context.TasksProgress;
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<TasksProgress> GetIndividualRecord(int id)
      {
          var record = _context.TasksProgress.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<TasksProgress>> PostRecord(TasksProgress record)
        {
            _context.TasksProgress.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new TasksProgress{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, TasksProgress record)
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
        public ActionResult<TasksProgress> DeleteRecord(int id)
        {
            var record = _context.TasksProgress.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.TasksProgress.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}