using FoodWeb_API.Data;
using FoodWeb_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _db;
        protected ApiResponse _response;
        public ShoppingCartController(AppDbContext db)
        {
            _response = new ApiResponse();
            _db = db;
        }

    }
}
