using Microsoft.AspNetCore.Identity;

namespace FoodWeb_API.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
