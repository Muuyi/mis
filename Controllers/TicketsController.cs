using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
      private readonly AuthenticationContext _context;
      public TicketsController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public JsonResult GetTicket(){
            var tickets =  _context.Tickets.Include(c => c.ApplicationUser).ToList();
            return  Json(tickets);
        }
    //   public ActionResult<IEnumerable<Tickets>> GetRecords()
    //   {
    //       return _context.Tickets;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Tickets> GetIndividualRecord(int id)
      {
          var record = _context.Tickets.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Tickets>> PostRecord(Tickets record)
        {
            _context.Tickets.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Tickets{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Tickets record)
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
        public ActionResult<Tickets> DeleteRecord(int id)
        {
            var record = _context.Tickets.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Tickets.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}