using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;
using mis.Models;
using AutoMapper;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;
// using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
      private readonly AuthenticationContext _context;
      private IMapper _mapper;
    //   public TasksController(AuthenticationContext context) => _context = context;
    public TasksController(AuthenticationContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }
      //GET             api/customers
      [HttpGet]
      public JsonResult GetAllTasks(){
        var tasks=  _context.Tasks.Include(c => c.ApplicationUser).Include(t => t.TasksProgress).ToList();
        return Json(tasks);
        }
    //   public ActionResult<IEnumerable<Tasks>> GetRecords()
    //   {
    //       return _context.Tasks;
    //   } 
      //GET INDIVIDUAL CLIENTS      api/customers/id
      [HttpGet("{id}")] 
      public ActionResult<Tasks> GetIndividualRecord(int id)
      {
          var record = _context.Tasks.Find(id);
          if(record == null)
          {
              return NotFound();
          }
          return record;
      }
        //POST DEPARTMENTS             api/departments
        [HttpPost]
        public ActionResult<IEnumerable<Tasks>> PostRecord(Tasks record)
        {
            _context.Tasks.Add(record);
            _context.SaveChanges();
            return CreatedAtAction("GetIndividualRecord", new Tasks{Id=record.Id},record);
        }
        //PUT DEPARTMENTS       api/departments/id
        [HttpPut("{id}")]
        public ActionResult PutRecord(int id, Tasks record)
        {
            if(id != record.Id)
            {
                return BadRequest();
            }
            _context.Entry(record).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //PATCH TASKS
        // public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<Tasks> patchModel){
        // //    var task = await _context.Tasks.SingleOrDefaultAsync(x=>x.Id==id);
        // var task =  _context.Tasks.Find(id);
        //    if(patchModel != null){
        //        patchModel.ApplyTo(task, ModelState);
        //        if (!ModelState.IsValid)
        //         {
        //             return BadRequest(ModelState);
        //         }
        //          _context.Entry(task).State = EntityState.Modified;
        //         await _context.SaveChangesAsync();
        //         return NoContent();
        //    }else{
        //        return BadRequest(ModelState);
        //    }
        
        // var taskToPatch = _mapper.Map<Tasks>(task);
        //    patchModel.ApplyTo(taskToPatch, ModelState);
        //    TryValidateModel(taskToPatch);
        //    if(!ModelState.IsValid){
        //        return BadRequest(ModelState);
        //    }
        //    _mapper.Map(taskToPatch,task);

        //    _context.Entry(task).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();

        // }
        // public ActionResult PatchRecord(int id)
        // {
        //     var record = _context.Tasks.Find(id);
        //     if(id != record.Id)
        //     {
        //         return BadRequest();
        //     }
        //     _context.Entry(record).State = EntityState.Modified;
        //     _context.SaveChanges();
        //     return NoContent();
        // }
        //DELETE RECORDS        api/departments/id
        [HttpDelete("{id}")]
        public ActionResult<Tasks> DeleteRecord(int id)
        {
            var record = _context.Tasks.Find(id);
            if(record == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(record);
            _context.SaveChanges();
            return record;
        }
    }
}
