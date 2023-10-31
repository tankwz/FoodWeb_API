using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb_API.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public IList<CartItem> CartItems { get; set; }
        [NotMapped]
        public double CartTotal {  get; set; }
    }

}
