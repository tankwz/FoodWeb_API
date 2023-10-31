using FoodWeb_API.Data;
using FoodWeb_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly AppDbContext _db;
        private ApiResponse _response;
        public OrderController(AppDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpGet] 
        public async Task<ActionResult<ApiResponse>> GetOrders(string? userId)
        {
            try
            {
                var OrderHeaders = await _db.OrderHead
                    .Include(a => a.OrderDetails)
                    .ThenInclude(a => a.MenuItem)
                    .OrderByDescending(a => a.OrderHeadId)
                    .ToListAsync();
                if (userId != null)
                {
                    _response.Result = OrderHeaders.Where(a => a.AppUserId == userId);
                }
                else
                {
                    _response.Result = OrderHeaders;
                }
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }catch (Exception ex) {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ApiResponse>> GetOrder(int id)
        {

            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                OrderHead order = await _db.OrderHead.Include(a => a.OrderDetails).FirstOrDefaultAsync(a => a.OrderHeadId == id);
                if(order == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound; return NotFound(_response);
                }

                _response.Result = order;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response) ;
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
