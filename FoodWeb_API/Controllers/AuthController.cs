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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Security.Claims;

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
        private ApiResponse _response;
        public AuthController(AppDbContext db, IConfiguration configuration, UserManager<AppUser> userm, RoleManager<IdentityRole> rolem)
        {
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _db = db;
            _userManager = userm;
            _roleManager = rolem;
            _response = new ApiResponse();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequestDTO register)
        {
            AppUser userFromDb = await _db.AppUsers.FirstOrDefaultAsync(a => a.UserName.ToLower() == register.UserName.ToLower());
            if (userFromDb != null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
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
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception ex) { }
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Error while registering");
            return BadRequest(_response);

        }
        [HttpPost("Login")]
        public async Task<ActionResult<ApiResponse>> Login(LoginRequestDTO login)
        {
            if (login.UserName == string.Empty || login.Password == string.Empty)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;

                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please enter username and password");
                return BadRequest(_response);
            }
            AppUser user = _db.AppUsers.FirstOrDefault(u => u.UserName == login.UserName);

            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please enter correct username or password");
                //wrong user name
                return BadRequest(_response);
            }
            bool correctPass = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!correctPass)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;

                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please enter correct username or password");
                //right username, wrong pass
                return BadRequest(_response);
            }
            //jwt token
            var role = await _userManager.GetRolesAsync(user);
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("fullName", user.Name),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponeDTO loginRespone = new()  
            {
                Email = user.Email,
                Token = tokenHandler.WriteToken(token),
            };
            if (loginRespone.Email == null || string.IsNullOrEmpty(loginRespone.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please enter correct username or password");
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = loginRespone;
                
            return Ok(_response);
        }

    }
}
