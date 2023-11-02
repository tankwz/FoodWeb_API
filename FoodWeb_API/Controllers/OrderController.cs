﻿using FoodWeb_API.Data;
using FoodWeb_API.Models;
using FoodWeb_API.Models.Dto;
using FoodWeb_API.Util;
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
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
             

            return _response;
        }

        [HttpPut]
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