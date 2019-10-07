using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;
using Newtonsoft.Json;
using mis.Models;
namespace mis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : Controller
    {
        // [HttpGet]
        // public ActionResult<IEnumerable<Administrators>> GetRecords()
        // {
        //     return _context.Administrators;
        // } 
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly AuthenticationContext _context;
        public ApplicationUserController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IOptions<ApplicationSettings> appSettings,AuthenticationContext context){
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _context = context;
        }
       
        // public ApplicationUserController () => ;
        [HttpGet]
        public JsonResult GetAllUsers(){
            var users=  _context.ApplicationUser.Include(c => c.Department).ToList();
            return  Json(users);
        }
        //POST METHOD
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser(){
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                DepartmentId = model.DepartmentId
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
        //LOGIN METHOD
        //POST METHOD
        [HttpPost]
        [Route("Login")]
        //POST: /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model){
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user != null && await _userManager.CheckPasswordAsync(user,model.Password)){
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim("UserId",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),SecurityAlgorithms.HmacSha256Signature)   
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }else{
                return BadRequest(new { message = "Username or Password is incorrect."});
            }
        }
        //HTTP PATCH METHOD
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(){
            return Ok("Success");
        }

    }
}