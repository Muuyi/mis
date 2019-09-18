using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingAttendanceController : Controller
    {
      private readonly AuthenticationContext _context;
      public MeetingAttendanceController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
       public JsonResult GetAllProjects(){
            var meeting =  _context.MeetingAttendance.ToList();
            return  Json(meeting);
        }
    //   public ActionResult<IEnumerable<Projects>> GetRecords()
    //   {
    //       return _context.Projects;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<MeetingAttendance> GetIndividualRecord(int id)
      {
          var record = _context.MeetingAttendance.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<MeetingAttendance>> PostRecord(MeetingAttendance record)
        {
            _context.MeetingAttendance.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new MeetingAttendance{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, MeetingAttendance record)
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
        public ActionResult<MeetingAttendance> DeleteRecord(int id)
        {
            var record = _context.MeetingAttendance.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.MeetingAttendance.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}