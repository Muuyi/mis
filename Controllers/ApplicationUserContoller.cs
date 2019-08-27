using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserContoller : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserContoller(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager){
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //POST METHOD
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser(){
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName

            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}