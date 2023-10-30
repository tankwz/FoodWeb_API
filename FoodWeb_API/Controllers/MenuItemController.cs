using FoodWeb_API.Data;
using FoodWeb_API.Models;
using FoodWeb_API.Models.Dto;
using FoodWeb_API.Models.Services;
using FoodWeb_API.Util;
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
        private readonly IBlobService _blob;
        public MenuItemController(AppDbContext db, IBlobService blob)
        {
            _db= db;
            _response = new ApiResponse();
            _blob = blob;
        }
        [HttpGet]
        public async Task<IActionResult> GetMenuItem()
        {
            _response.Result = await _db.MenuItems.ToListAsync();
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpGet("{id:int}", Name="GetMenuItem")]
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemCreateDTO == null || menuItemCreateDTO.Image.Length == 0) { 
                        return BadRequest();
                    }
                    string fileName = $"{menuItemCreateDTO.Name}{Guid.NewGuid()}{Path.GetExtension(menuItemCreateDTO.Image.FileName)}";
                    MenuItem menuItem = new()
                    {
                        Name = menuItemCreateDTO.Name,
                        Price = menuItemCreateDTO.Price,
                        Category = menuItemCreateDTO.Category,
                        SpecialTag = menuItemCreateDTO.SpecialTag,
                        Description = menuItemCreateDTO.Description,
                        Image = await _blob.UploadBlob(fileName, SD.SD_Storage_Container, menuItemCreateDTO.Image)
                    };
                    _db.MenuItems.AddAsync(menuItem);
                    _db.SaveChangesAsync();
                    _response.Result = menuItem;
                    return CreatedAtRoute("GetMenuItem", new {id = menuItem.Id},_response);
                }
                else
                {
                    _response.IsSuccess= false;
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }
    }
}
