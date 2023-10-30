using FoodWeb_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MenuItemController(AppDbContext db)
        {
            _db= db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItem()
        {

            return Ok(await _db.MenuItems.ToListAsync());
        }
    }
}
