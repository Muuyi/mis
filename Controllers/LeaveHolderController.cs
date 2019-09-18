using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveHolderController : Controller
    {
      private readonly AuthenticationContext _context;
      public LeaveHolderController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public JsonResult GetAllLeaveHolderList(){
            var leave =  _context.LeaveHolder.Include(e=>e.Employee).Include(c => c.Leave).ThenInclude(e=>e.Employee).ToList();
            return  Json(leave);
        }
    //   public ActionResult<IEnumerable<Leave>> GetRecords()
    //   {
    //       return _context.Leave;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<LeaveHolder> GetIndividualRecord(int id)
      {
          var record = _context.LeaveHolder.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<LeaveHolder>> PostRecord(LeaveHolder record)
        {
            _context.LeaveHolder.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new LeaveHolder{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, LeaveHolder record)
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
        public ActionResult<LeaveHolder> DeleteRecord(int id)
        {
            var record = _context.LeaveHolder.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.LeaveHolder.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}