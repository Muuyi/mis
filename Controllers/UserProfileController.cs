using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using mis.Models;
using System.IO;

namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
      [HttpGet]
      [Authorize]
      //GET: /api/UserProfile
      public async Task<Object> GetUserProfile(){
          string userId = User.Claims.First(c => c.Type == "UserId").Value;
          var user = await _userManager.FindByIdAsync(userId);
          return new 
          {
              user.FullName,
              user.Email,
              user.UserName,
              user.PhoneNumber,
              user.DepartmentId,
              user.ImageName
          };
      }
    //   [HttpPut]
    //   public async Task<IActionResult> UpdateUser(){
    //       string fileName = null;
    //       var httpRequest = HttpContext.Current.Request;
    //       var postedFile = httpRequest.Files["ImageName"];
    //       fileName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ","-");
    //       fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.fileName);
    //       var filePath = HttpContext.Current.Server.MapPath("~/Images/"+fileName);
    //       postedFile.SaveAs(filePath);

    //       return await "Done";
    //   }  
    }
}