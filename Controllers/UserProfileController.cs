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
              user.UserName
          };
      }  
    }
}