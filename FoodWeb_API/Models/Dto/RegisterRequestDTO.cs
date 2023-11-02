namespace FoodWeb_API.Models.Dto
{
    public class RegisterRequestDTO
    {
        public string UserName { get; set; } //email
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } //for testing, need to be remove when deploy

    }
}
