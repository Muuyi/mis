using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      private readonly DatabaseContext _context;
      public UsersController(DatabaseContext context) => _context = context;
      //GET             api/users
      [HttpGet]
      public ActionResult<IEnumerable<Users>> GetRecords()
      {
          return _context.Users;
      } 
      //GET INDIVIDUAL users      api/departments/id
      [HttpGet("{id}")] 
      public ActionResult<Users> GetIndividualRecord(int id)
      {
          var record = _context.Users.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Users>> PostRecord(Users record)
        {
            _context.Users.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Users {Id=record.Id},record);
        }
        //PUT RECORDS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Users record)
        {
            if(id != record.Id)
            {
                return BadRequest();
            }
            _context.Entry(record).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE DEPARTMENTS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Users> DeleteRecord(int id)
        {
            var record = _context.Users.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Users.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}