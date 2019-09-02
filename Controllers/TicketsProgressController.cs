using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsProgressController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public TicketsProgressController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public ActionResult<IEnumerable<TicketsProgress>> GetRecords()
      {
          return _context.TicketsProgress;
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<TicketsProgress> GetIndividualRecord(int id)
      {
          var record = _context.TicketsProgress.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<TicketsProgress>> PostRecord(TicketsProgress record)
        {
            _context.TicketsProgress.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new TicketsProgress{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, TicketsProgress record)
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
        public ActionResult<TicketsProgress> DeleteRecord(int id)
        {
            var record = _context.TicketsProgress.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.TicketsProgress.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}