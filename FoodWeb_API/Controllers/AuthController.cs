using FoodWeb_API.Data;
using FoodWeb_API.Models;
using FoodWeb_API.Models.Dto;
using FoodWeb_API.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace FoodWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private string secretKey;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApiResponse _respone;
        public AuthController(AppDbContext db, IConfiguration configuration, UserManager<AppUser> userm, RoleManager<IdentityRole> rolem)
        {
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _db = db;
            _userManager = userm;
            _roleManager = rolem;
            _respone = new ApiResponse();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequestDTO  register)
        {
            AppUser userFromDb = await _db.AppUsers.FirstOrDefaultAsync(a => a.UserName.ToLower() == register.UserName.ToLower());
            if(userFromDb != null) {
                _respone.IsSuccess = false;
                _respone.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _respone.ErrorMessages.Add("Username already exists");
                return BadRequest(_respone);
            }

            AppUser newUser = new()
            {
                UserName = register.UserName,
                Email = register.UserName,
                NormalizedEmail = register.UserName.ToUpper(),
                Name = register.Name
            };
            try
            {
                var result = await _userManager.CreateAsync(newUser, register.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));

                    }
                    if (register.Role == SD.Role_Admin)
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Customer);
                    }
                    _respone.StatusCode = HttpStatusCode.OK;
                    _respone.IsSuccess = true;
                    return Ok(_respone);
                }
            }
            catch(Exception ex) { }
            _respone.StatusCode = HttpStatusCode.BadRequest;
            _respone.IsSuccess = false;
            _respone.ErrorMessages.Add("Error while registering");
            return BadRequest(_respone);
    
        }


    }
}
