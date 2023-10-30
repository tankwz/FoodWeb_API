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
            _response = new ApiResponse();
        }
        [HttpGet]
        public async Task<IActionResult> GetMenuItem()
        {
            _response.Result = await _db.MenuItems.ToListAsync();
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            if(id == 0)
            {
                _response.StatusCode= System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            MenuItem item = await _db.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound; _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.Result = item;
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);

        }
    }
}
