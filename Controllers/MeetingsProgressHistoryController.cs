using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsProgressHistoryController : Controller
    {
      private readonly AuthenticationContext _context;
      public MeetingsProgressHistoryController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public JsonResult GetAllRecords(){
        var records=  _context.MeetingsProgressHistory.Include(c => c.Meetings).ToList();
        return Json(records);
        }
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      // public JsonResult GetIndividualRecords(int id){
      //   var records=  _context.MeetingsProgressHistory.Find(id).Include(c => c.Meetings).ToList();
      //   return Json(records);
      //   }
    //   public ActionResult<MeetingsProgressHistory> GetIndividualRecord(int id)
    //   {
    //       var record = _context.MeetingsProgressHistory.Find(id);
    //       if(record == null)
    //       {
    //           return NotFound();
    //       }
    //       return record;
    //   }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<MeetingsProgressHistory>> PostRecord(MeetingsProgressHistory record)
        {
            _context.MeetingsProgressHistory.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new MeetingsProgressHistory{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        // [HttpPut("{id}")]
        // public ActionResult PutRecord(int id, MeetingProgress record)
        // {
        //     if(id != record.Id)
        //     {
        //         return BadRequest();
        //     }
        //     _context.Entry(record).State = EntityState.Modified;
        //     _context.SaveChanges();
        //     return NoContent();
        // }
        // //DELETE RECORDS        api/departments/id
        // [HttpDelete("{id}")]
        // public ActionResult<MeetingProgress> DeleteRecord(int id)
        // {
        //     var record = _context.MeetingProgress.Find(id);
        //     if(record == null)
        //     {
        //         return NotFound();
        //     }
        //     _context.MeetingProgress.Remove(record);
        //     _context.SaveChanges();
        //     return record;
        // }
    }
}