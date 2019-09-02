using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
      private readonly AuthenticationContext _context;

      public AdministratorsController(AuthenticationContext context) => _context = context;
      //GET             api/users
      [HttpGet]
      public ActionResult<IEnumerable<Administrators>> GetRecords()
      {
          return _context.Administrators;
      } 
      //GET INDIVIDUAL users      api/departments/id
      [HttpGet("{id}")] 
      public ActionResult<Administrators> GetIndividualRecord(int id)
      {
          var record = _context.Administrators.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Administrators>> PostRecord(Administrators record)
        {
            _context.Administrators.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Administrators {Id=record.Id},record);
        }
        //PUT RECORDS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Administrators record)
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
        public ActionResult<Administrators> DeleteRecord(int id)
        {
            var record = _context.Administrators.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Administrators.Remove(record);
            _context.SaveChanges();
            return record;
        }
      [HttpGet("[action]")]
      public string SayHello() 
      {
          return "Hello world!!!";
      }
        //USER AUTHENTICATION
        // [HttpPost]
        // [Route("Login")]
        // public async Tasks<IActionResult> Login(LoginModel model)
        // {
        //     var user = await _context.Users.FindAsync(model.Username);

        // }
    }
}