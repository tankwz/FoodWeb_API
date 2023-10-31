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
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateCartItem(string userId, int itemId, int quantity)
        {
            ShoppingCart cart = await _db.ShoppingCarts.Include(a => a.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            MenuItem item = await _db.MenuItems.FirstOrDefaultAsync(i => i.Id == itemId);

            if (item == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if (cart == null && quantity > 0)
            {
                ShoppingCart newCart = new()
                {
                    UserId = userId,
                };

                await _db.ShoppingCarts.AddAsync(newCart);
                await _db.SaveChangesAsync();
                CartItem newCartItem = new()
                {
                    MenuItemId = itemId,
                    Quantity = quantity,
                    ShoppingCartId = newCart.Id,
                    MenuItem = null
                };
                await _db.CartItems.AddAsync(newCartItem);
                await _db.SaveChangesAsync();
            }
            else
            {
                CartItem checkCart = cart.CartItems.FirstOrDefault(u => u.MenuItemId == itemId);
                if (checkCart == null)
                {
                    CartItem newCartItem = new()
                    {
                        MenuItemId = itemId,
                        Quantity = quantity,
                        ShoppingCartId = cart.Id,
                        MenuItem = null

                    };
                    await _db.CartItems.AddAsync(newCartItem);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    int newQuantity = checkCart.Quantity + quantity;
                    if (quantity == 0 || newQuantity < 0)
                    {
                        _db.CartItems.Remove(checkCart);
                        if (cart.CartItems.Count() == 1)
                        {
                            _db.ShoppingCarts.Remove(cart);
                        }
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        checkCart.Quantity = newQuantity;
                        await _db.SaveChangesAsync();
                    }
                }
            }

            return _response    ;
        }

    }
}
