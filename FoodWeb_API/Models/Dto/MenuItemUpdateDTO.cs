using System.ComponentModel.DataAnnotations;

namespace FoodWeb_API.Models.Dto
{
    public class MenuItemUpdateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
