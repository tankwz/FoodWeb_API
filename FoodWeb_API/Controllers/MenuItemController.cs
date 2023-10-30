using FoodWeb_API.Data;
using FoodWeb_API.Models;
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
        private ApiResponse _response;
        public MenuItemController(AppDbContext db)
        {
            _db= db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItem()
        {
            _response.Result = await _db.MenuItems.ToListAsync();
            _response.StatusCode = System.Net.HttpStatusCode.OK;


            return Ok(_response);
        }
    }
}
