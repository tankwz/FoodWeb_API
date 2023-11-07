using FoodWeb_API.Data;
using FoodWeb_API.Models;
using FoodWeb_API.Models.Dto;
using FoodWeb_API.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

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
        public async Task<ActionResult<ApiResponse>> GetOrders(string? userId, string searchString, string status, int page=1, int size = 10)
        {
            try
            {
                
                IEnumerable<OrderHead>  OrderHeaders = await _db.OrderHead
                    .Include(a => a.OrderDetails)
                    .ThenInclude(a => a.MenuItem)
                    .OrderByDescending(a => a.OrderHeadId)
                    .ToListAsync();
                if (!string.IsNullOrEmpty(userId))
                {
                    OrderHeaders = OrderHeaders.Where(a => a.AppUserId == userId);
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    OrderHeaders = OrderHeaders.Where(u => u.PickupPhoneNumber.ToLower().Contains(searchString.ToLower()) || u.PickupName.ToLower().Contains(searchString.ToLower()) );

                }
                if (!string.IsNullOrEmpty(status))
                {
                    OrderHeaders = OrderHeaders.Where(u => u.Status.ToLower() == status.ToLower());

                }


                OrderFilterPage filterPage = new()
                {
                    CurrentPage = page,
                    HowManyRecords = size,
                    ForTotal = OrderHeaders.Count(),

                };

                Response.Headers.Add("X-OrderFilterPage", JsonSerializer.Serialize(filterPage));

                _response.Result = OrderHeaders.Skip((page-1)*size).Take(size);

                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            } catch (Exception ex) {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}")]

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

                OrderHead order = await _db.OrderHead.Include(a => a.OrderDetails).ThenInclude(a => a.MenuItem).FirstOrDefaultAsync(a => a.OrderHeadId == id);

                if (order == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound; return NotFound(_response);
                }
                AppUser user = await _db.AppUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == order.AppUserId);
                AppUser appUser = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                };
                order.AppUser = appUser;
                _response.Result = order;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }


            return _response;


        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateOrder([FromBody] OrderHeadCreateDTO orderHeadDTO)
        {
            try
            {
                OrderHead head = new()
                {
                    PickupName = orderHeadDTO.PickupName,
                    PickupPhoneNumber = orderHeadDTO.PickupPhoneNumber,
                    PickupAddress = orderHeadDTO.PickupAddress,
                    AppUserId = orderHeadDTO.AppUserId,
                    OrderTotal = orderHeadDTO.OrderTotal,
                    TotalItems = orderHeadDTO.TotalItems,
                    OrderDate = DateTime.Now,
                    Status = String.IsNullOrEmpty(orderHeadDTO.Status) ? SD.Status_Pending : orderHeadDTO.Status,
                };
                if (ModelState.IsValid)
                {
                    await _db.OrderHead.AddAsync(head);
                    await _db.SaveChangesAsync();
                    foreach (var detail in orderHeadDTO.OrderDetailsDTO)
                    {
                        OrderDetails orderDetail = new()
                        {
                            OrderHeadId = head.OrderHeadId,
                            MenuItemId = detail.MenuItemId,
                            ItemName = detail.ItemName,
                            Quantity = detail.Quantity,
                            Price = detail.Price,
                        };
                        await _db.OrderDetails.AddAsync(orderDetail);

                    }
                    await _db.SaveChangesAsync();
                    _response.Result = head;
                    _response.StatusCode = System.Net.HttpStatusCode.Created;
                    return Ok(_response);

                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }


            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateOrderHead(int id, [FromBody] OrderHeadUpdateDTO orderHeadDTO)
        {
            try
            {
                if(orderHeadDTO == null || orderHeadDTO.OrderHeadId != id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                OrderHead head = await _db.OrderHead.FirstOrDefaultAsync(a=>a.OrderHeadId == id);
                if(head == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                if(!string.IsNullOrEmpty(orderHeadDTO.PickupName))
                {
                    head.PickupName = orderHeadDTO.PickupName;
                }
                if (!string.IsNullOrEmpty(orderHeadDTO.PickupPhoneNumber))
                {
                    head.PickupPhoneNumber = orderHeadDTO.PickupPhoneNumber;
                }
                if (!string.IsNullOrEmpty(orderHeadDTO.PickupAddress))
                {
                    head.PickupAddress = orderHeadDTO.PickupAddress;
                }
                if (!string.IsNullOrEmpty(orderHeadDTO.Status))
                {
                    head.Status = orderHeadDTO.Status;
                }
                await _db.SaveChangesAsync();
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);   

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
