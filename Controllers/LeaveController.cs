using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public LeaveController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public ActionResult<IEnumerable<Leave>> GetRecords()
      {
          return _context.Leave;
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Leave> GetIndividualRecord(int id)
      {
          var record = _context.Leave.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Leave>> PostRecord(Leave record)
        {
            _context.Leave.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Leave{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Leave record)
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
        public ActionResult<Leave> DeleteRecord(int id)
        {
            var record = _context.Leave.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Leave.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}