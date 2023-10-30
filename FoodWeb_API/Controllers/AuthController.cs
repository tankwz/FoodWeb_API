using FoodWeb_API.Data;
using FoodWeb_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public AuthController(AppDbContext db, IConfiguration configuration)
        {
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            db = _db;
        }
    }
}
