using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWeb_API.Models.Dto
{
    public class OrderHeadCreateDTP
    {
        public int OrderHeadId { get; set; }
        public string PickupName { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupEmail { get; set; }



        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

    }
}
