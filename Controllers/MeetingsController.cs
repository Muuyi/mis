using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : Controller
    {
      private readonly AuthenticationContext _context;
      public MeetingsController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public JsonResult GetRecords()
      {
          var records =  _context.Meetings.Include(m => m.MeetingsProgressHistory).ToList();
          return Json(records);
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Meetings> GetIndividualRecord(int id)
      {
          var record = _context.Meetings.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Meetings>> PostRecord(Meetings record)
        {
            _context.Meetings.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Meetings{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Meetings record)
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
        public ActionResult<Meetings> DeleteRecord(int id)
        {
            var record = _context.Meetings.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Meetings.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}