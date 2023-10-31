using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb_API.Models
{
    public class OrderHead
    {
        [Key]
        public int OrderHeadId { get; set; }
        [Required]
        public string PickupName { get; set; }
        [Required]
        public string PickupPhoneNumber { get; set; }
        [Required]
        public string PickupEmail { get; set; }
        [Required]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderDate {  get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

    }
}
