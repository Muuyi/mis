using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
      private readonly AuthenticationContext _context;
      public CustomersController(AuthenticationContext context) => _context = context;
      //GET             api/customers
      [HttpGet]
      public ActionResult<IEnumerable<Customers>> GetRecords()
      {
          return _context.Customers;
      } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Customers> GetIndividualRecord(int id)
      {
          var record = _context.Customers.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Customers>> PostRecord(Customers record)
        {
            _context.Customers.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetRecords", new Customers{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Customers record)
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
        public ActionResult<Customers> DeleteRecord(int id)
        {
            var record = _context.Customers.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}